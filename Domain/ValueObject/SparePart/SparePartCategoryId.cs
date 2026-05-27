using System;

namespace Domain.ValueObject.SparePart;

public sealed record SparePartCategoryId
{
    public int Value { get; }

    private SparePartCategoryId(int value)
    {
        Value = value;
    }

    public static SparePartCategoryId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id de la categoría debe ser mayor a 0.", nameof(value));

        return new SparePartCategoryId(value);
    }

    public override string ToString() => Value.ToString();
}
