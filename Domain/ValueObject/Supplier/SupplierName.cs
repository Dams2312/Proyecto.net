using System;

namespace Domain.ValueObject.Supplier;

public sealed record SupplierName
{
    public string Value { get; }

    private SupplierName(string value)
    {
        Value = value;
    }

    public static SupplierName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El nombre del proveedor es obligatorio.", nameof(value));

        value = value.Trim();

        if (value.Length > 150)
            throw new ArgumentException("El nombre del proveedor no puede superar los 150 caracteres.", nameof(value));

        return new SupplierName(value);
    }

    public override string ToString() => Value;
}
