namespace Api.Dtos.UnitMeasure;

public sealed class CreateUnitMeasureRequest
{
    public string Name { get; init; } = default!;
    public string Abbreviation { get; init; } = default!;
}
