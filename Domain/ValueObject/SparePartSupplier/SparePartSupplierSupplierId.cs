using System;

namespace Domain.ValueObject.SparePartSupplier;

public sealed record SparePartSupplierSupplierId
{
    public int Value { get; }

    private SparePartSupplierSupplierId(int value)
    {
        Value = value;
    }

    public static SparePartSupplierSupplierId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id del proveedor debe ser mayor a 0.", nameof(value));

        return new SparePartSupplierSupplierId(value);
    }

    public override string ToString() => Value.ToString();
}
