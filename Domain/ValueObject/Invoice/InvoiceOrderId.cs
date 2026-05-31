using System;

namespace Domain.ValueObject.Invoice;

public sealed record InvoiceOrderId
{
    public Guid Value { get; }

    private InvoiceOrderId(Guid value)
    {
        Value = value;
    }

    public static InvoiceOrderId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("El id debe ser un Guid válido.", nameof(value));

        return new InvoiceOrderId(value);
    }

    public override string ToString() => Value.ToString();
}