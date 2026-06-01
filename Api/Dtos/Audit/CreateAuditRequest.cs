using System;

namespace Api.Dtos.Audit;

public sealed class CreateAuditRequest
{
    public string Entity { get; init; } = default!;
    public DateTime Date { get; init; }
    public string ActionType { get; init; } = default!;
    public string PreviousData { get; init; } = default!;
    public string NewData { get; init; } = default!;
    public string IpOrigin { get; init; } = default!;
}
