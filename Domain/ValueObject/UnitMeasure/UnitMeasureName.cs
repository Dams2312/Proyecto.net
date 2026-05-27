using System;

namespace Domain.ValueObject.UnitMeasure;

public sealed record UnitMeasureName
{
    public string Value { get; }

    private UnitMeasureName(string value)
    {
        Value = value;
    }

    public static UnitMeasureName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El nombre es obligatorio.", nameof(value));

        value = value.Trim();

        if (value.Length > 50)
            throw new ArgumentException("El nombre no puede superar los 50 caracteres.", nameof(value));

        return new UnitMeasureName(value);
    }

    public override string ToString() => Value;
}
