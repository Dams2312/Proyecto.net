using System;

namespace Domain.ValueObject.SparePart;

public sealed record SparePartUnitId
{
    public int Value { get; }

    private SparePartUnitId(int value)
    {
        Value = value;
    }

    public static SparePartUnitId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id de la unidad debe ser mayor a 0.", nameof(value));

        return new SparePartUnitId(value);
    }

    public override string ToString() => Value.ToString();
}
