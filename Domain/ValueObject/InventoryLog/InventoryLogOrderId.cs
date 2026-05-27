using System;

namespace Domain.ValueObject.InventoryLog;

public sealed record InventoryLogOrderId
{
    public int? Value { get; }

    private InventoryLogOrderId(int? value)
    {
        Value = value;
    }

    public static InventoryLogOrderId Create(int? value)
    {
        if (value.HasValue && value.Value <= 0)
            throw new ArgumentException("El id de la orden debe ser mayor a 0.", nameof(value));

        return new InventoryLogOrderId(value);
    }

    public override string ToString() => Value?.ToString() ?? string.Empty;
}
