using System;

namespace Domain.ValueObject.Purchase;

public sealed record PurchaseSupplierId
{
    public int Value { get; }

    private PurchaseSupplierId(int value)
    {
        Value = value;
    }

    public static PurchaseSupplierId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id del proveedor debe ser mayor a 0.", nameof(value));

        return new PurchaseSupplierId(value);
    }

    public override string ToString() => Value.ToString();
}
