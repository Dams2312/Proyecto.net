using System;

namespace Domain.ValueObject.InventoryLog;

public sealed record InventoryLogPurchaseId
{
    public int? Value { get; }

    private InventoryLogPurchaseId(int? value)
    {
        Value = value;
    }

    public static InventoryLogPurchaseId Create(int? value)
    {
        if (value.HasValue && value.Value <= 0)
            throw new ArgumentException("El id de la compra debe ser mayor a 0.", nameof(value));

        return new InventoryLogPurchaseId(value);
    }

    public override string ToString() => Value?.ToString() ?? string.Empty;
}
