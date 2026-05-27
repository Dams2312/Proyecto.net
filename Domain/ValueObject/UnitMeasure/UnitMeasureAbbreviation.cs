using System;

namespace Domain.ValueObject.UnitMeasure;

public sealed record UnitMeasureAbbreviation
{
    public string Value { get; }

    private UnitMeasureAbbreviation(string value)
    {
        Value = value;
    }

    public static UnitMeasureAbbreviation Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("La abreviatura es obligatoria.", nameof(value));

        value = value.Trim().ToUpperInvariant();

        if (value.Length > 10)
            throw new ArgumentException("La abreviatura no puede superar los 10 caracteres.", nameof(value));

        return new UnitMeasureAbbreviation(value);
    }

    public override string ToString() => Value;
}
