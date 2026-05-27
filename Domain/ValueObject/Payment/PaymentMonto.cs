using System;

namespace Domain.ValueObject.Payment;

public sealed record PaymentMonto
{
    public decimal Value { get; }

    private PaymentMonto(decimal value)
    {
        Value = value;
    }

    public static PaymentMonto Create(decimal value)
    {
        if (value <= 0)
            throw new ArgumentException("El monto del pago debe ser mayor a 0.", nameof(value));

        return new PaymentMonto(value);
    }

    public override string ToString() => Value.ToString("0.00");
}
