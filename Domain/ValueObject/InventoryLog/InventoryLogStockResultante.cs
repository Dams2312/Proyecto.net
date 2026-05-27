using System;

namespace Domain.ValueObject.InventoryLog;

public sealed record InventoryLogStockResultante
{
    public int Value { get; }

    private InventoryLogStockResultante(int value)
    {
        Value = value;
    }

    public static InventoryLogStockResultante Create(int value)
    {
        if (value < 0)
            throw new ArgumentException("El stock resultante no puede ser negativo.", nameof(value));

        return new InventoryLogStockResultante(value);
    }

    public override string ToString() => Value.ToString();
}
