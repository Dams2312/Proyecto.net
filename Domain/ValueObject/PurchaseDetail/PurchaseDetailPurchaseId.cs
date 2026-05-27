using System;

namespace Domain.ValueObject.PurchaseDetail;

public sealed record PurchaseDetailPurchaseId
{
    public int Value { get; }

    private PurchaseDetailPurchaseId(int value)
    {
        Value = value;
    }

    public static PurchaseDetailPurchaseId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id de la compra debe ser mayor a 0.", nameof(value));

        return new PurchaseDetailPurchaseId(value);
    }

    public override string ToString() => Value.ToString();
}
