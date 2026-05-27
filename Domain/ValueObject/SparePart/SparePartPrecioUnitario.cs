using System;

namespace Domain.ValueObject.SparePart;

public sealed record SparePartPrecioUnitario
{
    public decimal Value { get; }

    private SparePartPrecioUnitario(decimal value)
    {
        Value = value;
    }

    public static SparePartPrecioUnitario Create(decimal value)
    {
        if (value < 0)
            throw new ArgumentException("El precio unitario no puede ser negativo.", nameof(value));

        return new SparePartPrecioUnitario(value);
    }

    public override string ToString() => Value.ToString("0.00");
}
