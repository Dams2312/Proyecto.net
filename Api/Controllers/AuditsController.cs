using Api.Dtos.Audit;
using Application.Abstractions;
using Application.UseCase.Audit;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class AuditsController : BaseApiController
{
    private readonly IUnitOfWork _uow;
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public AuditsController(IUnitOfWork uow, ISender sender, IMapper mapper)
    {
        _uow = uow;
        _sender = sender;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<AuditDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<AuditDto>>> GetAll(CancellationToken ct)
    {
        var items = await _uow.Audits.GetAllAsync(ct);
        var result = _mapper.Map<IReadOnlyList<AuditDto>>(items);
        return Ok(result);
    }

    [HttpGet("paged")]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPaged([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string? search = null, CancellationToken ct = default)
    {
        if (page < 1) page = 1;
        if (pageSize < 1) pageSize = 10;

        var items = await _uow.Audits.GetPagedAsync(page, pageSize, search, ct);
        var total = await _uow.Audits.CountAsync(search, ct);
        var mapped = _mapper.Map<IReadOnlyList<AuditDto>>(items);
        return Ok(new { page, pageSize, total, items = mapped });
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(AuditDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AuditDto>> GetById(Guid id, CancellationToken ct)
    {
        var item = await _uow.Audits.GetByIdAsync(id, ct);
        if (item is null) return NotFound();
        return Ok(_mapper.Map<AuditDto>(item));
    }

    [HttpPost]
    [ProducesResponseType(typeof(AuditDto), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] CreateAuditRequest request, CancellationToken ct)
    {
        var command = _mapper.Map<CreateAudit>(request);
        var id = await _sender.Send(command, ct);
        var item = await _uow.Audits.GetByIdAsync(id, ct);
        if (item is null) return NotFound();
        return CreatedAtAction(nameof(GetById), new { id }, _mapper.Map<AuditDto>(item));
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAuditRequest request, CancellationToken ct)
    {
        var entity = await _uow.Audits.GetByIdAsync(id, ct);
        if (entity is null) return NotFound();
        var command = _mapper.Map<UpdateAudit>(request);
        await _sender.Send(command, ct);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        var entity = await _uow.Audits.GetByIdAsync(id, ct);
        if (entity is null) return NotFound();
        await _uow.Audits.RemoveAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);
        return NoContent();
    }
}
