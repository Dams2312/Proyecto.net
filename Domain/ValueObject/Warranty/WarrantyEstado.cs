using System;

namespace Domain.ValueObject.Warranty;

public sealed record WarrantyEstado
{
    public string Value { get; }

    private WarrantyEstado(string value)
    {
        Value = value;
    }

    public static WarrantyEstado Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El estado de la garantía es obligatorio.", nameof(value));

        value = value.Trim().ToLowerInvariant();

        if (value != "vigente" && value != "vencida" && value != "anulada" && value != "usada")
            throw new ArgumentException("El estado de la garantía debe ser 'vigente', 'vencida', 'anulada' o 'usada'.", nameof(value));

        return new WarrantyEstado(value);
    }

    public override string ToString() => Value;
}
