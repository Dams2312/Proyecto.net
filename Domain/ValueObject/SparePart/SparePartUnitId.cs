using System;

namespace Domain.ValueObject.SparePart;

public sealed record SparePartUnitId
{
    public Guid Value { get; }

    private SparePartUnitId(Guid value)
    {
        Value = value;
    }

    public static SparePartUnitId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("El id debe ser un Guid válido.", nameof(value));

        return new SparePartUnitId(value);
    }

    public override string ToString() => Value.ToString();
}