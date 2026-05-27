using System;

namespace Domain.ValueObject.Supplier;

public sealed record SupplierNit
{
    public string Value { get; }

    private SupplierNit(string value)
    {
        Value = value;
    }

    public static SupplierNit Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El NIT es obligatorio.", nameof(value));

        value = value.Trim();

        if (value.Length > 30)
            throw new ArgumentException("El NIT no puede superar los 30 caracteres.", nameof(value));

        return new SupplierNit(value);
    }

    public override string ToString() => Value;
}
