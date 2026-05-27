using System;

namespace Domain.ValueObject.Warranty;

public sealed record WarrantyCondiciones
{
    public string? Value { get; }

    private WarrantyCondiciones(string? value)
    {
        Value = value;
    }

    public static WarrantyCondiciones Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return new WarrantyCondiciones((string?)null);

        value = value.Trim();

        if (value.Length > 2000)
            throw new ArgumentException("Las condiciones no pueden superar los 2000 caracteres.", nameof(value));

        return new WarrantyCondiciones(value);
    }

    public override string ToString() => Value ?? string.Empty;
}
