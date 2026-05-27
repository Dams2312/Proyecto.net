using System;

namespace Domain.ValueObject.InventoryLog;

public sealed record InventoryLogTypeMovement
{
    public string Value { get; }

    private InventoryLogTypeMovement(string value)
    {
        Value = value;
    }

    public static InventoryLogTypeMovement Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El tipo de movimiento es obligatorio.", nameof(value));

        var normalized = value.Trim().ToLowerInvariant();

        if (normalized is not ("entrada" or "salida" or "ajuste"))
            throw new ArgumentException("El tipo de movimiento no es válido.", nameof(value));

        return new InventoryLogTypeMovement(normalized);
    }

    public override string ToString() => Value;
}
