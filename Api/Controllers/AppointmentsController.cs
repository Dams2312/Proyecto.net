using Api.Dtos.Appointment;
using Application.Abstractions;
using Application.UseCase.Appoinment;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class AppointmentsController : BaseApiController
{
    private readonly IUnitOfWork _uow;
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public AppointmentsController(
        IUnitOfWork uow,
        ISender sender,
        IMapper mapper)
    {
        _uow = uow;
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<AppointmentDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<AppointmentDto>>> GetAll(
        CancellationToken ct)
    {
        var items = await _uow.Appointments.GetAllAsync(ct);
        var result = _mapper.Map<IReadOnlyList<AppointmentDto>>(items);
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

        var items = await _uow.Appointments.GetPagedAsync(page, pageSize, search, ct);
        var total = await _uow.Appointments.CountAsync(search, ct);
        var mapped = _mapper.Map<IReadOnlyList<AppointmentDto>>(items);

        return Ok(new { page, pageSize, total, items = mapped });
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(AppointmentDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AppointmentDto>> GetById(
        Guid id,
        CancellationToken ct)
    {
        var item = await _uow.Appointments.GetByIdAsync(id, ct);
        if (item is null) return NotFound();
        var result = _mapper.Map<AppointmentDto>(item);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(AppointmentDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create(
        [FromBody] CreateAppointmentRequest request,
        CancellationToken ct)
    {
        var command = _mapper.Map<CreateAppointment>(request);
        var id = await _sender.Send(command, ct);

        var item = await _uow.Appointments.GetByIdAsync(id, ct);
        if (item is null) return NotFound();

        var result = _mapper.Map<AppointmentDto>(item);
        return CreatedAtAction(nameof(GetById), new { id }, result);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(
        Guid id,
        [FromBody] UpdateAppointmentRequest request,
        CancellationToken ct)
    {
        var entity = await _uow.Appointments.GetByIdAsync(id, ct);
        if (entity is null) return NotFound();

        var command = _mapper.Map<UpdateAppointment>(request);
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
        var entity = await _uow.Appointments.GetByIdAsync(id, ct);
        if (entity is null) return NotFound();

        await _uow.Appointments.RemoveAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return NoContent();
    }
}
