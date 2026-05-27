using System;

namespace Domain.ValueObject.Invoice;

public sealed record InvoiceDescuento
{
    public decimal Value { get; }

    private InvoiceDescuento(decimal value)
    {
        Value = value;
    }

    public static InvoiceDescuento Create(decimal value)
    {
        if (value < 0)
            throw new ArgumentException("El descuento no puede ser negativo.", nameof(value));

        return new InvoiceDescuento(value);
    }

    public override string ToString() => Value.ToString("0.00");
}
