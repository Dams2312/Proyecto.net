using System;

namespace Api.Dtos.Warranty;

public sealed class CreateWarrantyRequest
{
    public Guid OrderId { get; init; }
    public Guid ServiceTypeId { get; init; }
    public Guid MechanicId { get; init; }
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
    public string Status { get; init; } = default!;
    public string Conditions { get; init; } = default!;
}
