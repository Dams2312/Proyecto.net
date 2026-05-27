using System;

namespace Domain.ValueObject.Invoice;

public sealed record InvoiceTotal
{
    public decimal Value { get; }

    private InvoiceTotal(decimal value)
    {
        Value = value;
    }

    public static InvoiceTotal Create(decimal value)
    {
        if (value < 0)
            throw new ArgumentException("El total no puede ser negativo.", nameof(value));

        return new InvoiceTotal(value);
    }

    public override string ToString() => Value.ToString("0.00");
}
