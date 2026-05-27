using System;

namespace Domain.ValueObject.OrderDetail;

public sealed record OrderDetailOrderId
{
    public int Value { get; }

    private OrderDetailOrderId(int value)
    {
        Value = value;
    }

    public static OrderDetailOrderId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id de la orden debe ser mayor a 0.", nameof(value));

        return new OrderDetailOrderId(value);
    }

    public override string ToString() => Value.ToString();
}
