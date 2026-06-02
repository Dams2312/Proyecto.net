using Api.Dtos.Supplier;
using Application.Abstractions;
using Application.UseCase.Supplier;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class SuppliersController : BaseApiController
{
    private readonly IUnitOfWork _uow;
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public SuppliersController(IUnitOfWork uow, ISender sender, IMapper mapper)
    {
        _uow = uow;
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<SupplierDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<SupplierDto>>> GetAll(CancellationToken ct)
    {
        var items = await _uow.Suppliers.GetAllAsync(ct);
        return Ok(_mapper.Map<IReadOnlyList<SupplierDto>>(items));
    }

    [HttpGet("paged")]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPaged([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string? search = null, CancellationToken ct = default)
    {
        if (page < 1) page = 1;
        if (pageSize < 1) pageSize = 10;

        var items = await _uow.Suppliers.GetPagedAsync(page, pageSize, search, ct);
        var total = await _uow.Suppliers.CountAsync(search, ct);
        var mapped = _mapper.Map<IReadOnlyList<SupplierDto>>(items);

        return Ok(new { page, pageSize, total, items = mapped });
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(SupplierDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SupplierDto>> GetById(Guid id, CancellationToken ct)
    {
        var item = await _uow.Suppliers.GetByIdAsync(id, ct);
        if (item is null) return NotFound();
        return Ok(_mapper.Map<SupplierDto>(item));
    }

    [HttpPost]
    [ProducesResponseType(typeof(SupplierDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] CreateSupplierRequest request, CancellationToken ct)
    {
        var command = _mapper.Map<CreateSupplier>(request);
        var id = await _sender.Send(command, ct);
        var item = await _uow.Suppliers.GetByIdAsync(id, ct);
        if (item is null) return NotFound();
        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<SupplierDto>(item));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateSupplierRequest request, CancellationToken ct)
    {
        var entity = await _uow.Suppliers.GetByIdAsync(id, ct);
        if (entity is null) return NotFound();

        var command = _mapper.Map<UpdateSupplier>(request) with { Id = id };
        await _sender.Send(command, ct);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        var entity = await _uow.Suppliers.GetByIdAsync(id, ct);
        if (entity is null) return NotFound();

        await _uow.Suppliers.RemoveAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return NoContent();
    }
}
