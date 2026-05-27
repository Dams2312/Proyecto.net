using System;

namespace Domain.ValueObject.Payment;

public sealed record PaymentReferencia
{
    public string? Value { get; }

    private PaymentReferencia(string? value)
    {
        Value = value;
    }

    public static PaymentReferencia Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return new PaymentReferencia((string?)null);

        value = value.Trim();

        if (value.Length > 100)
            throw new ArgumentException("La referencia no puede superar los 100 caracteres.", nameof(value));

        return new PaymentReferencia(value);
    }

    public override string ToString() => Value ?? string.Empty;
}
