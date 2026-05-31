using System;

namespace Domain.ValueObject.SparePartSupplier;

public sealed record SparePartSupplierSparePartId
{
    public Guid Value { get; }

    private SparePartSupplierSparePartId(Guid value)
    {
        Value = value;
    }

    public static SparePartSupplierSparePartId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("El id debe ser un Guid válido.", nameof(value));

        return new SparePartSupplierSparePartId(value);
    }

    public override string ToString() => Value.ToString();
}