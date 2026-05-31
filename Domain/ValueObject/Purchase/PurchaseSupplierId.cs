using System;

namespace Domain.ValueObject.Purchase;

public sealed record PurchaseSupplierId
{
    public Guid Value { get; }

    private PurchaseSupplierId(Guid value)
    {
        Value = value;
    }

    public static PurchaseSupplierId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("El id debe ser un Guid válido.", nameof(value));

        return new PurchaseSupplierId(value);
    }

    public override string ToString() => Value.ToString();
}