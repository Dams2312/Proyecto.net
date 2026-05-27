using System;

namespace Domain.ValueObject.InvoiceStatus;

public sealed record InvoiceStatusName
{
    public string Value { get; }

    private InvoiceStatusName(string value)
    {
        Value = value;
    }

    public static InvoiceStatusName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El nombre del estado es obligatorio.", nameof(value));

        value = value.Trim();

        if (value.Length > 50)
            throw new ArgumentException("El nombre del estado no puede superar los 50 caracteres.", nameof(value));

        return new InvoiceStatusName(value);
    }

    public override string ToString() => Value;
}
