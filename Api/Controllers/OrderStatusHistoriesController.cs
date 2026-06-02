using Api.Dtos.OrderStatusHistory;
using Application.Abstractions;
using Application.UseCase.OrderStatusHistory;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class OrderStatusHistoriesController : BaseApiController
{
    private readonly IUnitOfWork _uow;
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public OrderStatusHistoriesController(IUnitOfWork uow, ISender sender, IMapper mapper)
    {
        _uow = uow;
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<OrderStatusHistoryDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<OrderStatusHistoryDto>>> GetAll(CancellationToken ct)
    {
        var items = await _uow.OrderStatusHistories.GetAllAsync(ct);
        return Ok(_mapper.Map<IReadOnlyList<OrderStatusHistoryDto>>(items));
    }

    [HttpGet("paged")]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPaged([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string? search = null, CancellationToken ct = default)
    {
        if (page < 1) page = 1;
        if (pageSize < 1) pageSize = 10;
        var items = await _uow.OrderStatusHistories.GetPagedAsync(page, pageSize, search, ct);
        var total = await _uow.OrderStatusHistories.CountAsync(search, ct);
        var mapped = _mapper.Map<IReadOnlyList<OrderStatusHistoryDto>>(items);
        return Ok(new { page, pageSize, total, items = mapped });
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(OrderStatusHistoryDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<OrderStatusHistoryDto>> GetById(Guid id, CancellationToken ct)
    {
        var item = await _uow.OrderStatusHistories.GetByIdAsync(id, ct);
        if (item is null) return NotFound();
        return Ok(_mapper.Map<OrderStatusHistoryDto>(item));
    }

    [HttpPost]
    [ProducesResponseType(typeof(OrderStatusHistoryDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] CreateOrderStatusHistoryRequest request, CancellationToken ct)
    {
        var command = _mapper.Map<CreateOrderStatusHistory>(request);
        var id = await _sender.Send(command, ct);
        var item = await _uow.OrderStatusHistories.GetByIdAsync(id, ct);
        if (item is null) return NotFound();
        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<OrderStatusHistoryDto>(item));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateOrderStatusHistoryRequest request, CancellationToken ct)
    {
        var entity = await _uow.OrderStatusHistories.GetByIdAsync(id, ct);
        if (entity is null) return NotFound();
        var command = _mapper.Map<UpdateOrderStatusHistory>(request);
        await _sender.Send(command, ct);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        var entity = await _uow.OrderStatusHistories.GetByIdAsync(id, ct);
        if (entity is null) return NotFound();
        await _uow.OrderStatusHistories.RemoveAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);
        return NoContent();
    }
}
