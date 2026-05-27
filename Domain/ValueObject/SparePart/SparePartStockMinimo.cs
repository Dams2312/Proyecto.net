using System;

namespace Domain.ValueObject.SparePart;

public sealed record SparePartStockMinimo
{
    public int Value { get; }

    private SparePartStockMinimo(int value)
    {
        Value = value;
    }

    public static SparePartStockMinimo Create(int value)
    {
        if (value < 0)
            throw new ArgumentException("El stock mínimo no puede ser negativo.", nameof(value));

        return new SparePartStockMinimo(value);
    }

    public override string ToString() => Value.ToString();
}
