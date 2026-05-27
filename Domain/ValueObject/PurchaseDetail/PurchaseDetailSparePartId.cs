using System;

namespace Domain.ValueObject.PurchaseDetail;

public sealed record PurchaseDetailSparePartId
{
    public int Value { get; }

    private PurchaseDetailSparePartId(int value)
    {
        Value = value;
    }

    public static PurchaseDetailSparePartId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id del repuesto debe ser mayor a 0.", nameof(value));

        return new PurchaseDetailSparePartId(value);
    }

    public override string ToString() => Value.ToString();
}
