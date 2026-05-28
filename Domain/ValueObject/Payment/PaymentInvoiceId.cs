using System;

namespace Domain.ValueObject.Payment;

public sealed record PaymentInvoiceId
{
    public int Value { get; }

    private PaymentInvoiceId(int value)
    {
        Value = value;
    }

    public static PaymentInvoiceId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id de la factura debe ser mayor a 0.", nameof(value));

        return new PaymentInvoiceId(value);
    }

    public override string ToString() => Value.ToString();
}
