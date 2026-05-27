using System;

namespace Domain.ValueObject.OrderStatusHistory;

public sealed record OrderStatusHistoryStatusId
{
    public int Value { get; }

    private OrderStatusHistoryStatusId(int value)
    {
        Value = value;
    }

    public static OrderStatusHistoryStatusId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id del estado debe ser mayor a 0.", nameof(value));

        return new OrderStatusHistoryStatusId(value);
    }

    public override string ToString() => Value.ToString();
}
