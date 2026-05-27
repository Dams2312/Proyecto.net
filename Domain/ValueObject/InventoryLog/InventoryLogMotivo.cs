using System;

namespace Domain.ValueObject.InventoryLog;

public sealed record InventoryLogMotivo
{
    public string? Value { get; }

    private InventoryLogMotivo(string? value)
    {
        Value = value;
    }

    public static InventoryLogMotivo Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return new InventoryLogMotivo((string?)null);

        value = value.Trim();

        if (value.Length > 2000)
            throw new ArgumentException("El motivo no puede superar los 2000 caracteres.", nameof(value));

        return new InventoryLogMotivo(value);
    }

    public override string ToString() => Value ?? string.Empty;
}
