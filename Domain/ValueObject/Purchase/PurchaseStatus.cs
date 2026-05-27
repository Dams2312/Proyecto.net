using System;

namespace Domain.ValueObject.Purchase;

public sealed record PurchaseStatus
{
    public string Value { get; }

    private PurchaseStatus(string value)
    {
        Value = value;
    }

    public static PurchaseStatus Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El estado es obligatorio.", nameof(value));

        var normalized = value.Trim().ToLowerInvariant();

        if (normalized is not ("pendiente" or "recibida" or "cancelada"))
            throw new ArgumentException("El estado no es válido.", nameof(value));

        return new PurchaseStatus(normalized);
    }

    public override string ToString() => Value;
}
