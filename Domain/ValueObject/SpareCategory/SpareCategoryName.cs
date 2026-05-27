using System;

namespace Domain.ValueObject.SpareCategory;

public sealed record SpareCategoryName
{
    public string Value { get; }

    private SpareCategoryName(string value)
    {
        Value = value;
    }

    public static SpareCategoryName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El nombre es obligatorio.", nameof(value));

        value = value.Trim();

        if (value.Length > 80)
            throw new ArgumentException("El nombre no puede superar los 80 caracteres.", nameof(value));

        return new SpareCategoryName(value);
    }

    public override string ToString() => Value;
}
