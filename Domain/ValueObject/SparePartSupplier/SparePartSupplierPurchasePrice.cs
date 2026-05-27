using System;

namespace Domain.ValueObject.SparePartSupplier;

public sealed record SparePartSupplierPurchasePrice
{
    public decimal Value { get; }

    private SparePartSupplierPurchasePrice(decimal value)
    {
        Value = value;
    }

    public static SparePartSupplierPurchasePrice Create(decimal value)
    {
        if (value < 0)
            throw new ArgumentException("El precio de compra no puede ser negativo.", nameof(value));

        return new SparePartSupplierPurchasePrice(value);
    }

    public override string ToString() => Value.ToString("0.00");
}
