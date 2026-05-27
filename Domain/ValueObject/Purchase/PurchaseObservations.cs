using System;

namespace Domain.ValueObject.Purchase;

public sealed record PurchaseObservations
{
    public string? Value { get; }

    private PurchaseObservations(string? value)
    {
        Value = value;
    }

    public static PurchaseObservations Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return new PurchaseObservations((string?)null);

        value = value.Trim();

        if (value.Length > 2000)
            throw new ArgumentException("Las observaciones no pueden superar los 2000 caracteres.", nameof(value));

        return new PurchaseObservations(value);
    }

    public override string ToString() => Value ?? string.Empty;
}
