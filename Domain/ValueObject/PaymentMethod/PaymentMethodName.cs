using System;

namespace Domain.ValueObject.PaymentMethod;

public sealed record PaymentMethodName
{
    public string Value { get; }

    private PaymentMethodName(string value)
    {
        Value = value;
    }

    public static PaymentMethodName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El nombre del método de pago es obligatorio.", nameof(value));

        value = value.Trim();

        if (value.Length > 50)
            throw new ArgumentException("El nombre del método de pago no puede superar los 50 caracteres.", nameof(value));

        return new PaymentMethodName(value);
    }

    public override string ToString() => Value;
}
