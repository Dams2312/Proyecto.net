using System;

namespace Api.Dtos.VehicleModel;

public sealed class CreateVehicleModelRequest
{
    public Guid BrandId { get; init; }
    public string Name { get; init; } = default!;
    public int? YearFrom { get; init; }
    public int? YearTo { get; init; }
}
