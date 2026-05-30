using System;

namespace Api.Dtos.UnitMeasure;

public sealed class UnitMeasureDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = default!;
    public string Abbreviation { get; init; } = default!;
}
