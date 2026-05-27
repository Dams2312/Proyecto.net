using System;

namespace Domain.ValueObject.OrderStatusHistory;

public sealed record OrderStatusHistoryUserId
{
    public int Value { get; }

    private OrderStatusHistoryUserId(int value)
    {
        Value = value;
    }

    public static OrderStatusHistoryUserId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id del usuario debe ser mayor a 0.", nameof(value));

        return new OrderStatusHistoryUserId(value);
    }

    public override string ToString() => Value.ToString();
}
