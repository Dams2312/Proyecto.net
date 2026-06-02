using Api.Dtos.InvoiceStatus;
using Application.Abstractions;
using Application.UseCase.InvoiceStatus;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class InvoiceStatusesController : BaseApiController
{
    private readonly IUnitOfWork _uow;
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public InvoiceStatusesController(IUnitOfWork uow, ISender sender, IMapper mapper)
    {
        _uow = uow;
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<InvoiceStatusDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<InvoiceStatusDto>>> GetAll(CancellationToken ct)
    {
        var items = await _uow.InvoiceStatuses.GetAllAsync(ct);
        return Ok(_mapper.Map<IReadOnlyList<InvoiceStatusDto>>(items));
    }

    [HttpGet("paged")]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPaged([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string? search = null, CancellationToken ct = default)
    {
        if (page < 1) page = 1;
        if (pageSize < 1) pageSize = 10;
        var items = await _uow.InvoiceStatuses.GetPagedAsync(page, pageSize, search, ct);
        var total = await _uow.InvoiceStatuses.CountAsync(search, ct);
        var mapped = _mapper.Map<IReadOnlyList<InvoiceStatusDto>>(items);
        return Ok(new { page, pageSize, total, items = mapped });
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(InvoiceStatusDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<InvoiceStatusDto>> GetById(Guid id, CancellationToken ct)
    {
        var item = await _uow.InvoiceStatuses.GetByIdAsync(id, ct);
        if (item is null) return NotFound();
        return Ok(_mapper.Map<InvoiceStatusDto>(item));
    }

    [HttpPost]
    [ProducesResponseType(typeof(InvoiceStatusDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] CreateInvoiceStatusRequest request, CancellationToken ct)
    {
        var command = _mapper.Map<CreateInvoiceStatus>(request);
        var id = await _sender.Send(command, ct);
        var item = await _uow.InvoiceStatuses.GetByIdAsync(id, ct);
        if (item is null) return NotFound();
        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<InvoiceStatusDto>(item));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateInvoiceStatusRequest request, CancellationToken ct)
    {
        var entity = await _uow.InvoiceStatuses.GetByIdAsync(id, ct);
        if (entity is null) return NotFound();
        var command = _mapper.Map<UpdateInvoiceStatus>(request);
        await _sender.Send(command, ct);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        var entity = await _uow.InvoiceStatuses.GetByIdAsync(id, ct);
        if (entity is null) return NotFound();
        await _uow.InvoiceStatuses.RemoveAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);
        return NoContent();
    }
}
