using System;

namespace Domain.ValueObject.Warranty;

public sealed record WarrantyFechaVencimiento
{
    public DateOnly Value { get; }

    private WarrantyFechaVencimiento(DateOnly value)
    {
        Value = value;
    }

    public static WarrantyFechaVencimiento Create(DateOnly value)
    {
        if (value == default)
            throw new ArgumentException("La fecha de vencimiento de la garantía es obligatoria.", nameof(value));

        return new WarrantyFechaVencimiento(value);
    }

    public override string ToString() => Value.ToString("yyyy-MM-dd");
}
