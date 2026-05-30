using System;

namespace Api.Dtos.Vehicle;

public sealed class VehicleDto
{
    public Guid Id { get; init; }
    public Guid ClientId { get; init; }
    public Guid ModelId { get; init; }
    public string ModelName { get; init; } = default!;
    public string Vin { get; init; } = default!;
    public string Plate { get; init; } = default!;
    public int Year { get; init; }
    public string Color { get; init; } = default!;
    public bool Active { get; init; }
}
