using System;

namespace Domain.ValueObject.InventoryLog;

public sealed record InventoryLogSparePartId
{
    public int Value { get; }

    private InventoryLogSparePartId(int value)
    {
        Value = value;
    }

    public static InventoryLogSparePartId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id del repuesto debe ser mayor a 0.", nameof(value));

        return new InventoryLogSparePartId(value);
    }

    public override string ToString() => Value.ToString();
}
