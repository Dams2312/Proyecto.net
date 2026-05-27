using System;

namespace Domain.ValueObject.Purchase;

public sealed record PurchaseUserId
{
    public int Value { get; }

    private PurchaseUserId(int value)
    {
        Value = value;
    }

    public static PurchaseUserId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id del usuario debe ser mayor a 0.", nameof(value));

        return new PurchaseUserId(value);
    }

    public override string ToString() => Value.ToString();
}
