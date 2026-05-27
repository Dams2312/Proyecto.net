using System;

namespace Domain.ValueObject.Invoice;

public sealed record InvoiceOrderId
{
    public int Value { get; }

    private InvoiceOrderId(int value)
    {
        Value = value;
    }

    public static InvoiceOrderId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id de la orden debe ser mayor a 0.", nameof(value));

        return new InvoiceOrderId(value);
    }

    public override string ToString() => Value.ToString();
}
