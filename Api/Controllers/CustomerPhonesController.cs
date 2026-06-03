using Api.Dtos.CustomerPhone;
using Application.Abstractions;
using Application.UseCase.CustomerPhone;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class CustomerPhonesController : BaseApiController
{
    private readonly IUnitOfWork _uow;
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public CustomerPhonesController(
        IUnitOfWork uow,
        ISender sender,
        IMapper mapper)
    {
        _uow = uow;
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<CustomerPhoneDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<CustomerPhoneDto>>> GetAll(
        CancellationToken ct)
    {
        var items = await _uow.CustomerPhones.GetAllAsync(ct);
        var result = _mapper.Map<IReadOnlyList<CustomerPhoneDto>>(items);
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

        var items = await _uow.CustomerPhones.GetPagedAsync(page, pageSize, search, ct);
        var total = await _uow.CustomerPhones.CountAsync(search, ct);
        var mapped = _mapper.Map<IReadOnlyList<CustomerPhoneDto>>(items);

        return Ok(new { page, pageSize, total, items = mapped });
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(CustomerPhoneDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CustomerPhoneDto>> GetById(
        Guid id,
        CancellationToken ct)
    {
        var item = await _uow.CustomerPhones.GetByIdAsync(id, ct);
        if (item is null) return NotFound();
        var result = _mapper.Map<CustomerPhoneDto>(item);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(CustomerPhoneDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(
        [FromBody] CreateCustomerPhoneRequest request,
        CancellationToken ct)
    {
        var command = _mapper.Map<CreateCustomerPhone>(request);
        var id = await _sender.Send(command, ct);

        var item = await _uow.CustomerPhones.GetByIdAsync(id, ct);
        if (item is null) return NotFound();

        var result = _mapper.Map<CustomerPhoneDto>(item);
        return CreatedAtAction(nameof(GetById), new { id }, result);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(
        Guid id,
        [FromBody] UpdateCustomerPhoneRequest request,
        CancellationToken ct)
    {
        var entity = await _uow.CustomerPhones.GetByIdAsync(id, ct);
        if (entity is null) return NotFound();

        var command = _mapper.Map<UpdateCustomerPhone>(request);
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
        var entity = await _uow.CustomerPhones.GetByIdAsync(id, ct);
        if (entity is null) return NotFound();

        await _uow.CustomerPhones.RemoveAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return NoContent();
    }
}