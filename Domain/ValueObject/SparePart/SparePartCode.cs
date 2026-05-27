using System;

namespace Domain.ValueObject.SparePart;

public sealed record SparePartCode
{
    public string Value { get; }

    private SparePartCode(string value)
    {
        Value = value;
    }

    public static SparePartCode Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El código es obligatorio.", nameof(value));

        value = value.Trim().ToUpperInvariant();

        if (value.Length > 50)
            throw new ArgumentException("El código no puede superar los 50 caracteres.", nameof(value));

        return new SparePartCode(value);
    }

    public override string ToString() => Value;
}
