namespace Domain.ValueObject.City;

public sealed record CityCode
{
    public string Value { get; private set; } = default!;

    private CityCode() { } // <- EF Core

    private CityCode(string value)
    {
        Value = value;
    }

    public static CityCode Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El código de la ciudad es obligatorio.", nameof(value));

        var normalized = value.Trim().ToUpperInvariant();

        if (normalized.Length > 10)
            throw new ArgumentException("El código de la ciudad no puede tener más de 10 caracteres.", nameof(value));

        return new CityCode(normalized);
    }

    public override string ToString() => Value;
}