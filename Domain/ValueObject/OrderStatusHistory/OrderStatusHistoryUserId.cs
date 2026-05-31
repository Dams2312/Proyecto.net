using System;

namespace Domain.ValueObject.OrderStatusHistory;

public sealed record OrderStatusHistoryUserId
{
    public Guid Value { get; }

    private OrderStatusHistoryUserId(Guid value)
    {
        Value = value;
    }

    public static OrderStatusHistoryUserId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("El id debe ser un Guid válido.", nameof(value));

        return new OrderStatusHistoryUserId(value);
    }

    public override string ToString() => Value.ToString();
}