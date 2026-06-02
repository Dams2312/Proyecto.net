using Api.Dtos.OrderDetail;
using Application.Abstractions;
using Application.UseCase.OrderDetail;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class OrderDetailsController : BaseApiController
{
    private readonly IUnitOfWork _uow;
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public OrderDetailsController(IUnitOfWork uow, ISender sender, IMapper mapper)
    {
        _uow = uow;
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<OrderDetailDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<OrderDetailDto>>> GetAll(CancellationToken ct)
    {
        var items = await _uow.OrderDetails.GetAllAsync(ct);
        return Ok(_mapper.Map<IReadOnlyList<OrderDetailDto>>(items));
    }

    [HttpGet("paged")]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPaged([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string? search = null, CancellationToken ct = default)
    {
        if (page < 1) page = 1;
        if (pageSize < 1) pageSize = 10;
        var items = await _uow.OrderDetails.GetPagedAsync(page, pageSize, search, ct);
        var total = await _uow.OrderDetails.CountAsync(search, ct);
        var mapped = _mapper.Map<IReadOnlyList<OrderDetailDto>>(items);
        return Ok(new { page, pageSize, total, items = mapped });
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(OrderDetailDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<OrderDetailDto>> GetById(Guid id, CancellationToken ct)
    {
        var item = await _uow.OrderDetails.GetByIdAsync(id, ct);
        if (item is null) return NotFound();
        return Ok(_mapper.Map<OrderDetailDto>(item));
    }

    [HttpPost]
    [ProducesResponseType(typeof(OrderDetailDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] CreateOrderDetailRequest request, CancellationToken ct)
    {
        var command = _mapper.Map<CreateOrderDetail>(request);
        var id = await _sender.Send(command, ct);
        var item = await _uow.OrderDetails.GetByIdAsync(id, ct);
        if (item is null) return NotFound();
        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<OrderDetailDto>(item));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateOrderDetailRequest request, CancellationToken ct)
    {
        var entity = await _uow.OrderDetails.GetByIdAsync(id, ct);
        if (entity is null) return NotFound();
        var command = _mapper.Map<UpdateOrderDetail>(request);
        await _sender.Send(command, ct);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        var entity = await _uow.OrderDetails.GetByIdAsync(id, ct);
        if (entity is null) return NotFound();
        await _uow.OrderDetails.RemoveAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);
        return NoContent();
    }
}
