using System;

namespace Domain.ValueObject.OrderStatusHistory;

public sealed record OrderStatusHistoryOrderId
{
    public int Value { get; }

    private OrderStatusHistoryOrderId(int value)
    {
        Value = value;
    }

    public static OrderStatusHistoryOrderId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id de la orden debe ser mayor a 0.", nameof(value));

        return new OrderStatusHistoryOrderId(value);
    }

    public override string ToString() => Value.ToString();
}
