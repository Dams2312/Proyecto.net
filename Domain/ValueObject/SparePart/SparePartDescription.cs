using System;

namespace Domain.ValueObject.SparePart;

public sealed record SparePartDescription
{
    public string Value { get; }

    private SparePartDescription(string value)
    {
        Value = value;
    }

    public static SparePartDescription Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("La descripción es obligatoria.", nameof(value));

        value = value.Trim();

        if (value.Length > 255)
            throw new ArgumentException("La descripción no puede superar los 255 caracteres.", nameof(value));

        return new SparePartDescription(value);
    }

    public override string ToString() => Value;
}
