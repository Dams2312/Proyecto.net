using Api.Dtos.Vehicle;
using Application.Abstractions;
using Application.UseCase.Vehicle;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class VehiclesController : BaseApiController
{
    private readonly IUnitOfWork _uow;
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public VehiclesController(IUnitOfWork uow, ISender sender, IMapper mapper)
    {
        _uow = uow;
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<VehicleDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<VehicleDto>>> GetAll(CancellationToken ct)
    {
        var items = await _uow.Vehicles.GetAllAsync(ct);
        return Ok(_mapper.Map<IReadOnlyList<VehicleDto>>(items));
    }

    [HttpGet("paged")]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPaged([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string? search = null, CancellationToken ct = default)
    {
        if (page < 1) page = 1;
        if (pageSize < 1) pageSize = 10;

        var items = await _uow.Vehicles.GetPagedAsync(page, pageSize, search, ct);
        var total = await _uow.Vehicles.CountAsync(search, ct);
        var mapped = _mapper.Map<IReadOnlyList<VehicleDto>>(items);

        return Ok(new { page, pageSize, total, items = mapped });
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(VehicleDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<VehicleDto>> GetById(Guid id, CancellationToken ct)
    {
        var item = await _uow.Vehicles.GetByIdAsync(id, ct);
        if (item is null) return NotFound();
        return Ok(_mapper.Map<VehicleDto>(item));
    }

    [HttpPost]
    [Authorize(Policy = "ReceptionistOrAdmin")]
    [ProducesResponseType(typeof(VehicleDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] CreateVehicleRequest request, CancellationToken ct)
    {
        var command = _mapper.Map<CreateVehicle>(request);
        var id = await _sender.Send(command, ct);
        var item = await _uow.Vehicles.GetByIdAsync(id, ct);
        if (item is null) return NotFound();
        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<VehicleDto>(item));
    }

    [HttpPut("{id:guid}")]
    [Authorize(Policy = "ReceptionistOrAdmin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateVehicleRequest request, CancellationToken ct)
    {
        var entity = await _uow.Vehicles.GetByIdAsync(id, ct);
        if (entity is null) return NotFound();

        var command = _mapper.Map<UpdateVehicle>(request) with { Id = id };
        await _sender.Send(command, ct);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Policy = "AdminOnly")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        var entity = await _uow.Vehicles.GetByIdAsync(id, ct);
        if (entity is null) return NotFound();

        await _uow.Vehicles.RemoveAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return NoContent();
    }
}
