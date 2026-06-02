using Api.Dtos.OrderNote;
using Application.Abstractions;
using Application.UseCase.OrderNote;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class OrderNotesController : BaseApiController
{
    private readonly IUnitOfWork _uow;
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public OrderNotesController(IUnitOfWork uow, ISender sender, IMapper mapper)
    {
        _uow = uow;
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<OrderNoteDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<OrderNoteDto>>> GetAll(CancellationToken ct)
    {
        var items = await _uow.OrderNotes.GetAllAsync(ct);
        return Ok(_mapper.Map<IReadOnlyList<OrderNoteDto>>(items));
    }

    [HttpGet("paged")]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPaged([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string? search = null, CancellationToken ct = default)
    {
        if (page < 1) page = 1;
        if (pageSize < 1) pageSize = 10;
        var items = await _uow.OrderNotes.GetPagedAsync(page, pageSize, search, ct);
        var total = await _uow.OrderNotes.CountAsync(search, ct);
        var mapped = _mapper.Map<IReadOnlyList<OrderNoteDto>>(items);
        return Ok(new { page, pageSize, total, items = mapped });
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(OrderNoteDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<OrderNoteDto>> GetById(Guid id, CancellationToken ct)
    {
        var item = await _uow.OrderNotes.GetByIdAsync(id, ct);
        if (item is null) return NotFound();
        return Ok(_mapper.Map<OrderNoteDto>(item));
    }

    [HttpPost]
    [ProducesResponseType(typeof(OrderNoteDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] CreateOrderNoteRequest request, CancellationToken ct)
    {
        var command = _mapper.Map<CreateOrderNote>(request);
        var id = await _sender.Send(command, ct);
        var item = await _uow.OrderNotes.GetByIdAsync(id, ct);
        if (item is null) return NotFound();
        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<OrderNoteDto>(item));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateOrderNoteRequest request, CancellationToken ct)
    {
        var entity = await _uow.OrderNotes.GetByIdAsync(id, ct);
        if (entity is null) return NotFound();
        var command = _mapper.Map<UpdateOrderNote>(request);
        await _sender.Send(command, ct);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        var entity = await _uow.OrderNotes.GetByIdAsync(id, ct);
        if (entity is null) return NotFound();
        await _uow.OrderNotes.RemoveAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);
        return NoContent();
    }
}
