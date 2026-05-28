using System;

namespace Domain.ValueObject.Payment;

public sealed record PaymentMethodId
{
    public int Value { get; }

    private PaymentMethodId(int value)
    {
        Value = value;
    }

    public static PaymentMethodId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id del método de pago debe ser mayor a 0.", nameof(value));

        return new PaymentMethodId(value);
    }

    public override string ToString() => Value.ToString();
}
