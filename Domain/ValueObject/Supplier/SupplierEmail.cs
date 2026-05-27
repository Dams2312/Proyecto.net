using System;

namespace Domain.ValueObject.Supplier;

public sealed record SupplierEmail
{
    public string? Value { get; }

    private SupplierEmail(string? value)
    {
        Value = value;
    }

    public static SupplierEmail Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return new SupplierEmail((string?)null);

        value = value.Trim();

        if (value.Length > 150)
            throw new ArgumentException("El correo no puede superar los 150 caracteres.", nameof(value));

        return new SupplierEmail(value);
    }

    public override string ToString() => Value ?? string.Empty;
}
