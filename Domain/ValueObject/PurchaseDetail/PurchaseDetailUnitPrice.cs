using System;

namespace Domain.ValueObject.PurchaseDetail;

public sealed record PurchaseDetailUnitPrice
{
    public decimal Value { get; }

    private PurchaseDetailUnitPrice(decimal value)
    {
        Value = value;
    }

    public static PurchaseDetailUnitPrice Create(decimal value)
    {
        if (value < 0)
            throw new ArgumentException("El precio unitario no puede ser negativo.", nameof(value));

        return new PurchaseDetailUnitPrice(value);
    }

    public override string ToString() => Value.ToString("0.00");
}
