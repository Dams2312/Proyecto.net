using System;

namespace Domain.ValueObject.InventoryLog;

public sealed record InventoryLogQuantity
{
    public int Value { get; }

    private InventoryLogQuantity(int value)
    {
        Value = value;
    }

    public static InventoryLogQuantity Create(int value)
    {
        if (value == 0)
            throw new ArgumentException("La cantidad no puede ser cero.", nameof(value));

        return new InventoryLogQuantity(value);
    }

    public override string ToString() => Value.ToString();
}
