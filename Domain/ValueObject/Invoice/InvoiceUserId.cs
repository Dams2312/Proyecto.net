using System;

namespace Domain.ValueObject.Invoice;

public sealed record InvoiceUserId
{
    public Guid Value { get; }

    private InvoiceUserId(Guid value)
    {
        Value = value;
    }

    public static InvoiceUserId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("El id debe ser un Guid válido.", nameof(value));

        return new InvoiceUserId(value);
    }

    public override string ToString() => Value.ToString();
}