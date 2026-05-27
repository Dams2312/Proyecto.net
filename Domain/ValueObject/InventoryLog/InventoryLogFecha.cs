using System;

namespace Domain.ValueObject.InventoryLog;

public sealed record InventoryLogFecha
{
    public DateTime Value { get; }

    private InventoryLogFecha(DateTime value)
    {
        Value = value;
    }

    public static InventoryLogFecha Create(DateTime value)
    {
        if (value == default)
            throw new ArgumentException("La fecha del movimiento es obligatoria.", nameof(value));

        return new InventoryLogFecha(value);
    }

    public override string ToString() => Value.ToString("yyyy-MM-dd HH:mm:ss");
}
