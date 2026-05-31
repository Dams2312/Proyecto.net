using System;

namespace Domain.ValueObject.Invoice;

public sealed record InvoiceStatusId
{
    public Guid Value { get; }

    private InvoiceStatusId(Guid value)
    {
        Value = value;
    }

    public static InvoiceStatusId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("El id debe ser un Guid válido.", nameof(value));

        return new InvoiceStatusId(value);
    }

    public override string ToString() => Value.ToString();
}