using System;

namespace Domain.ValueObject.Payment;

public sealed record PaymentMethodId
{
    public Guid Value { get; }

    private PaymentMethodId(Guid value)
    {
        Value = value;
    }

    public static PaymentMethodId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException(
                "El id del método de pago es obligatorio.",
                nameof(value));

        return new PaymentMethodId(value);
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}