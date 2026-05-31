using System;

namespace Domain.ValueObject.InventoryLog;

public sealed record InventoryLogSparePartId
{
    public Guid Value { get; }

    private InventoryLogSparePartId(Guid value)
    {
        Value = value;
    }

    public static InventoryLogSparePartId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("El id debe ser un Guid válido.", nameof(value));

        return new InventoryLogSparePartId(value);
    }

    public override string ToString() => Value.ToString();
}