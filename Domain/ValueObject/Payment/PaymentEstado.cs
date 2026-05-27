using System;

namespace Domain.ValueObject.Payment;

public sealed record PaymentEstado
{
    public string Value { get; }

    private PaymentEstado(string value)
    {
        Value = value;
    }

    public static PaymentEstado Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El estado del pago es obligatorio.", nameof(value));

        value = value.Trim().ToLowerInvariant();

        if (value != "completado" && value != "anulado" && value != "pendiente")
            throw new ArgumentException("El estado del pago debe ser 'completado', 'anulado' o 'pendiente'.", nameof(value));

        return new PaymentEstado(value);
    }

    public override string ToString() => Value;
}
