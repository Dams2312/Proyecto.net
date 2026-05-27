using System;

namespace Domain.ValueObject.SpareCategory;

public sealed record SpareCategoryDescription
{
    public string? Value { get; }

    private SpareCategoryDescription(string? value)
    {
        Value = value;
    }

    public static SpareCategoryDescription Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return new SpareCategoryDescription((string?)null);

        value = value.Trim();

        if (value.Length > 2000)
            throw new ArgumentException("La descripción no puede superar los 2000 caracteres.", nameof(value));

        return new SpareCategoryDescription(value);
    }

    public override string ToString() => Value ?? string.Empty;
}
