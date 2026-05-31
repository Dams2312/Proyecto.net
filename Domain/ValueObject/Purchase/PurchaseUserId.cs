using System;

namespace Domain.ValueObject.Purchase;

public sealed record PurchaseUserId
{
    public Guid Value { get; }

    private PurchaseUserId(Guid value)
    {
        Value = value;
    }

    public static PurchaseUserId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("El id debe ser un Guid válido.", nameof(value));

        return new PurchaseUserId(value);
    }

    public override string ToString() => Value.ToString();
}