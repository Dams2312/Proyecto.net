namespace Api.Dtos.UnitMeasure;

public sealed class UpdateUnitMeasureRequest
{
    public string Name { get; init; } = default!;
    public string Abbreviation { get; init; } = default!;
}
