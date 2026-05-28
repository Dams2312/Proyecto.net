using System;

namespace Domain.ValueObject.PaymentMethod;

public sealed record PaymentMethodDescription
{
    public string? Value { get; }

    private PaymentMethodDescription(string? value)
    {
        Value = value;
    }

    public static PaymentMethodDescription Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return new PaymentMethodDescription(null);

        value = value.Trim();

        if (value.Length > 2000)
            throw new ArgumentException("La descripción del método de pago no puede superar los 2000 caracteres.", nameof(value));

        return new PaymentMethodDescription(value);
    }

    public override string ToString() => Value ?? string.Empty;
}
