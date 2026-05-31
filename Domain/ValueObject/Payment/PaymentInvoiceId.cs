using System;

namespace Domain.ValueObject.Payment;

public sealed record PaymentInvoiceId
{
    public Guid Value { get; }

    private PaymentInvoiceId(Guid value)
    {
        Value = value;
    }

    public static PaymentInvoiceId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException(
                "El id de la factura es obligatorio.",
                nameof(value));

        return new PaymentInvoiceId(value);
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}