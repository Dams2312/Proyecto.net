using System;

namespace Domain.ValueObject.SparePart;

public sealed record SparePartStockActual
{
    public int Value { get; }

    private SparePartStockActual(int value)
    {
        Value = value;
    }

    public static SparePartStockActual Create(int value)
    {
        if (value < 0)
            throw new ArgumentException("El stock actual no puede ser negativo.", nameof(value));

        return new SparePartStockActual(value);
    }

    public override string ToString() => Value.ToString();
}
