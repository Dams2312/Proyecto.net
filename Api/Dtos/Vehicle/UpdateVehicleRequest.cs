using System;

namespace Api.Dtos.Vehicle;

public sealed class UpdateVehicleRequest
{
    public Guid ClientId { get; init; }
    public Guid ModelId { get; init; }
    public string Vin { get; init; } = default!;
    public string Plate { get; init; } = default!;
    public int Year { get; init; }
    public string Color { get; init; } = default!;
    public bool Active { get; init; }
}
