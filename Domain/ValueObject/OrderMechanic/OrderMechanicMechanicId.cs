using System;

namespace Domain.ValueObject.OrderMechanic;

public sealed record OrderMechanicMechanicId
{
    public int Value { get; }

    private OrderMechanicMechanicId(int value)
    {
        Value = value;
    }

    public static OrderMechanicMechanicId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id del mecánico debe ser mayor a 0.", nameof(value));

        return new OrderMechanicMechanicId(value);
    }

    public override string ToString() => Value.ToString();
}
