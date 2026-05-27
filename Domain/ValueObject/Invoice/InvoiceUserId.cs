using System;

namespace Domain.ValueObject.Invoice;

public sealed record InvoiceUserId
{
    public int Value { get; }

    private InvoiceUserId(int value)
    {
        Value = value;
    }

    public static InvoiceUserId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id del usuario debe ser mayor a 0.", nameof(value));

        return new InvoiceUserId(value);
    }

    public override string ToString() => Value.ToString();
}
