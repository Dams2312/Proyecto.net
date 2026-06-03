using Api.Dtos.CustomerAddress;
using Application.Abstractions;
using Application.UseCase.CustomerAddress;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class CustomerAddressesController : BaseApiController
{
    private readonly IUnitOfWork _uow;
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public CustomerAddressesController(
        IUnitOfWork uow,
        ISender sender,
        IMapper mapper)
    {
        _uow = uow;
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<CustomerAddressDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<CustomerAddressDto>>> GetAll(
        CancellationToken ct)
    {
        var items = await _uow.CustomerAddresses.GetAllAsync(ct);
        var result = _mapper.Map<IReadOnlyList<CustomerAddressDto>>(items);
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

        var items = await _uow.CustomerAddresses.GetPagedAsync(page, pageSize, search, ct);
        var total = await _uow.CustomerAddresses.CountAsync(search, ct);
        var mapped = _mapper.Map<IReadOnlyList<CustomerAddressDto>>(items);

        return Ok(new { page, pageSize, total, items = mapped });
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(CustomerAddressDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CustomerAddressDto>> GetById(
        Guid id,
        CancellationToken ct)
    {
        var item = await _uow.CustomerAddresses.GetByIdAsync(id, ct);
        if (item is null) return NotFound();
        var result = _mapper.Map<CustomerAddressDto>(item);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(CustomerAddressDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(
        [FromBody] CreateCustomerAddressRequest request,
        CancellationToken ct)
    {
        var command = _mapper.Map<CreateCustomerAddress>(request);
        var id = await _sender.Send(command, ct);

        var item = await _uow.CustomerAddresses.GetByIdAsync(id, ct);
        if (item is null) return NotFound();

        var result = _mapper.Map<CustomerAddressDto>(item);
        return CreatedAtAction(nameof(GetById), new { id }, result);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(
        Guid id,
        [FromBody] UpdateCustomerAddressRequest request,
        CancellationToken ct)
    {
        var entity = await _uow.CustomerAddresses.GetByIdAsync(id, ct);
        if (entity is null) return NotFound();

        var command = _mapper.Map<UpdateCustomerAddress>(request);
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
        var entity = await _uow.CustomerAddresses.GetByIdAsync(id, ct);
        if (entity is null) return NotFound();

        await _uow.CustomerAddresses.RemoveAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return NoContent();
    }
}