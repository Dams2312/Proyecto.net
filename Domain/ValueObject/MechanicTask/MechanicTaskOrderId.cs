using System;

namespace Domain.ValueObject.MechanicTask;

public sealed record MechanicTaskOrderId
{
    public int Value { get; }

    private MechanicTaskOrderId(int value)
    {
        Value = value;
    }

    public static MechanicTaskOrderId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id de la orden debe ser mayor a 0.", nameof(value));

        return new MechanicTaskOrderId(value);
    }

    public override string ToString() => Value.ToString();
}
