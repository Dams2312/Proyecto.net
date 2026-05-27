using System;

namespace Domain.ValueObject.Invoice;

public sealed record InvoiceStatusId
{
    public int Value { get; }

    private InvoiceStatusId(int value)
    {
        Value = value;
    }

    public static InvoiceStatusId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id del estado de factura debe ser mayor a 0.", nameof(value));

        return new InvoiceStatusId(value);
    }

    public override string ToString() => Value.ToString();
}
