using System;

namespace Domain.ValueObject.InventoryLog;

public sealed record InventoryLogUserId
{
    public Guid Value { get; }

    private InventoryLogUserId(Guid value)
    {
        Value = value;
    }

    public static InventoryLogUserId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("El id debe ser un Guid válido.", nameof(value));

        return new InventoryLogUserId(value);
    }

    public override string ToString() => Value.ToString();
}