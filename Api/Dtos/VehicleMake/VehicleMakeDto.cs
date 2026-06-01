using System;

namespace Api.Dtos.VehicleMake;

public sealed class VehicleMakeDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = default!;
}
