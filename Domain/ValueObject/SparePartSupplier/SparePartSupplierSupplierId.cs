using System;

namespace Domain.ValueObject.SparePartSupplier;

public sealed record SparePartSupplierSupplierId
{
    public Guid Value { get; }

    private SparePartSupplierSupplierId(Guid value)
    {
        Value = value;
    }

    public static SparePartSupplierSupplierId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("El id debe ser un Guid válido.", nameof(value));

        return new SparePartSupplierSupplierId(value);
    }

    public override string ToString() => Value.ToString();
}