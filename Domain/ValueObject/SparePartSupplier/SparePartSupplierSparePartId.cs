using System;

namespace Domain.ValueObject.SparePartSupplier;

public sealed record SparePartSupplierSparePartId
{
    public int Value { get; }

    private SparePartSupplierSparePartId(int value)
    {
        Value = value;
    }

    public static SparePartSupplierSparePartId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id del repuesto debe ser mayor a 0.", nameof(value));

        return new SparePartSupplierSparePartId(value);
    }

    public override string ToString() => Value.ToString();
}
