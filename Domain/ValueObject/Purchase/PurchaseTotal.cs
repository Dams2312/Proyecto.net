using System;

namespace Domain.ValueObject.Purchase;

public sealed record PurchaseTotal
{
    public decimal Value { get; }

    private PurchaseTotal(decimal value)
    {
        Value = value;
    }

    public static PurchaseTotal Create(decimal value)
    {
        if (value < 0)
            throw new ArgumentException("El total no puede ser negativo.", nameof(value));

        return new PurchaseTotal(value);
    }

    public override string ToString() => Value.ToString("0.00");
}
