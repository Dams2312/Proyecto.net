using System;

namespace Domain.ValueObject.OrderDetail;

public sealed record OrderDetailQuantity
{
    public int Value { get; }

    private OrderDetailQuantity(int value)
    {
        Value = value;
    }

    public static OrderDetailQuantity Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("La cantidad debe ser mayor a 0.", nameof(value));

        return new OrderDetailQuantity(value);
    }

    public override string ToString() => Value.ToString();
}
