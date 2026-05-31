using System;

namespace Domain.ValueObject.OrderStatusHistory;

public sealed record OrderStatusHistoryOrderId
{
    public Guid Value { get; }

    private OrderStatusHistoryOrderId(Guid value)
    {
        Value = value;
    }

    public static OrderStatusHistoryOrderId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("El id debe ser un Guid válido.", nameof(value));

        return new OrderStatusHistoryOrderId(value);
    }

    public override string ToString() => Value.ToString();
}