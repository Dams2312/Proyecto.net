using System;

namespace Api.Dtos.MileageHistory;

public sealed class MileageHistoryDto
{
    public Guid Id { get; init; }
    public Guid VehicleId { get; init; }
    public string VehicleReference { get; init; } = default!;
    public int Mileage { get; init; }
    public DateTime Date { get; init; }
    public string Source { get; init; } = default!;
}
