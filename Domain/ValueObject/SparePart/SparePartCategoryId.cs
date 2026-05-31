using System;

namespace Domain.ValueObject.SparePart;

public sealed record SparePartCategoryId
{
    public Guid Value { get; }

    private SparePartCategoryId(Guid value)
    {
        Value = value;
    }

    public static SparePartCategoryId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("El id debe ser un Guid válido.", nameof(value));

        return new SparePartCategoryId(value);
    }

    public override string ToString() => Value.ToString();
}