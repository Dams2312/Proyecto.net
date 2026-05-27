using System;

namespace Domain.ValueObject.InventoryLog;

public sealed record InventoryLogUserId
{
    public int Value { get; }

    private InventoryLogUserId(int value)
    {
        Value = value;
    }

    public static InventoryLogUserId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id del usuario debe ser mayor a 0.", nameof(value));

        return new InventoryLogUserId(value);
    }

    public override string ToString() => Value.ToString();
}
