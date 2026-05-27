using System;

namespace Domain.ValueObject.Supplier;

public sealed record SupplierPhone
{
    public string? Value { get; }

    private SupplierPhone(string? value)
    {
        Value = value;
    }

    public static SupplierPhone Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return new SupplierPhone((string?)null);

        value = value.Trim();

        if (value.Length > 20)
            throw new ArgumentException("El teléfono no puede superar los 20 caracteres.", nameof(value));

        return new SupplierPhone(value);
    }

    public override string ToString() => Value ?? string.Empty;
}
