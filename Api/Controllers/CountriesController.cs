using Api.Dtos.Contries;
using Application.Abstractions;
using Application.UseCase.Countries;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class CountriesController : BaseApiController
{
    private readonly IUnitOfWork _uow;
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public CountriesController(
        IUnitOfWork uow,
        ISender sender,
        IMapper mapper)
    {
        _uow = uow;
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<CountryDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<CountryDto>>> GetAll(
        CancellationToken ct)
    {
        var countries = await _uow.Countries.GetAllAsync(ct);
        var result = _mapper.Map<IReadOnlyList<CountryDto>>(countries);
        return Ok(result);
    }

    [HttpGet("paged")]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPaged(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string? search = null,
        CancellationToken ct = default)
    {
        if (page < 1)
            page = 1;

        if (pageSize < 1)
            pageSize = 10;

        var countries = await _uow.Countries.GetPagedAsync(page, pageSize, search, ct);
        var total = await _uow.Countries.CountAsync(search, ct);
        var items = _mapper.Map<IReadOnlyList<CountryDto>>(countries);

        return Ok(new
        {
            page,
            pageSize,
            total,
            items
        });
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(CountryDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CountryDto>> GetById(
        Guid id,
        CancellationToken ct)
    {
        var country = await _uow.Countries.GetByIdAsync(id, ct);

        if (country is null)
            return NotFound();

        var result = _mapper.Map<CountryDto>(country);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(CountryDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(
        [FromBody] CreateCountryRequest request,
        CancellationToken ct)
    {
        var command = _mapper.Map<CreateCountry>(request);
        var id = await _sender.Send(command, ct);

        var country = await _uow.Countries.GetByIdAsync(id, ct);
        if (country is null)
            return NotFound();

        var result = _mapper.Map<CountryDto>(country);
        return CreatedAtAction(
            nameof(GetById),
            new { id },
            result);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(
        Guid id,
        [FromBody] UpdateCountryRequest request,
        CancellationToken ct)
    {
        var country = await _uow.Countries.GetByIdAsync(id, ct);
        if (country is null)
            return NotFound();

        var command = new UpdateCountry(id, request.Name, request.Code);
        await _sender.Send(command, ct);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(
        Guid id,
        CancellationToken ct)
    {
        var country = await _uow.Countries.GetByIdAsync(id, ct);
        if (country is null)
            return NotFound();

        await _uow.Countries.RemoveAsync(country, ct);
        await _uow.SaveChangesAsync(ct);

        return NoContent();
    }
}
