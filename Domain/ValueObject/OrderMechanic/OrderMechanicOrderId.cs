using System;

namespace Domain.ValueObject.OrderMechanic;

public sealed record OrderMechanicOrderId
{
    public int Value { get; }

    private OrderMechanicOrderId(int value)
    {
        Value = value;
    }

    public static OrderMechanicOrderId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id de la orden debe ser mayor a 0.", nameof(value));

        return new OrderMechanicOrderId(value);
    }

    public override string ToString() => Value.ToString();
}
