using System;

namespace Api.Dtos.MileageHistory;

public sealed class CreateMileageHistoryRequest
{
    public Guid VehicleId { get; init; }
    public int Mileage { get; init; }
    public DateTime Date { get; init; }
    public string Source { get; init; } = default!;
}
