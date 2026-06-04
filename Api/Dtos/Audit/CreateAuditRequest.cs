using System;

namespace Api.Dtos.Audit;

public sealed class CreateAuditRequest
{
    public Guid UserId { get; init; }
    public Guid EntidadId { get; init; }
    public string Entity { get; init; } = default!;
    public DateTime Date { get; init; }
    public string ActionType { get; init; } = default!;
    public string? PreviousData { get; init; }
    public string? NewData { get; init; }
    public string? IpOrigin { get; init; }
}