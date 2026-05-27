using System;

namespace Domain.ValueObject.OrderServiceType;

public sealed record OrderServiceTypeOrderId
{
    public int Value { get; }

    private OrderServiceTypeOrderId(int value)
    {
        Value = value;
    }

    public static OrderServiceTypeOrderId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id de la orden debe ser mayor a 0.", nameof(value));

        return new OrderServiceTypeOrderId(value);
    }

    public override string ToString() => Value.ToString();
}
