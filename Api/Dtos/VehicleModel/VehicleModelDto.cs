using System;

namespace Api.Dtos.VehicleModel;

public sealed class VehicleModelDto
{
    public Guid Id { get; init; }
    public Guid BrandId { get; init; }
    public string BrandName { get; init; } = default!;
    public string Name { get; init; } = default!;
    public int? YearFrom { get; init; }
    public int? YearTo { get; init; }
}
