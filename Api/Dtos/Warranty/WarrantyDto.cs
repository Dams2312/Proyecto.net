using System;

namespace Api.Dtos.Warranty;

public sealed class WarrantyDto
{
    public Guid Id { get; init; }
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
    public string Status { get; init; } = default!;
    public string Conditions { get; init; } = default!;
}
