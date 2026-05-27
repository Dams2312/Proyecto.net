using System;

namespace Domain.ValueObject.PurchaseDetail;

public sealed record PurchaseDetailQuantity
{
    public int Value { get; }

    private PurchaseDetailQuantity(int value)
    {
        Value = value;
    }

    public static PurchaseDetailQuantity Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("La cantidad debe ser mayor a 0.", nameof(value));

        return new PurchaseDetailQuantity(value);
    }

    public override string ToString() => Value.ToString();
}
