using System;

namespace Domain.ValueObject.Warranty;

public sealed record WarrantyFechaInicio
{
    public DateOnly Value { get; }

    private WarrantyFechaInicio(DateOnly value)
    {
        Value = value;
    }

    public static WarrantyFechaInicio Create(DateOnly value)
    {
        if (value == default)
            throw new ArgumentException("La fecha de inicio de la garantía es obligatoria.", nameof(value));

        return new WarrantyFechaInicio(value);
    }

    public override string ToString() => Value.ToString("yyyy-MM-dd");
}
