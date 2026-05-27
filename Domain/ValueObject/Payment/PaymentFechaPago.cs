using System;

namespace Domain.ValueObject.Payment;

public sealed record PaymentFechaPago
{
    public DateTime Value { get; }

    private PaymentFechaPago(DateTime value)
    {
        Value = value;
    }

    public static PaymentFechaPago Create(DateTime value)
    {
        if (value == default)
            throw new ArgumentException("La fecha de pago es obligatoria.", nameof(value));

        return new PaymentFechaPago(value);
    }

    public override string ToString() => Value.ToString("yyyy-MM-dd HH:mm:ss");
}
