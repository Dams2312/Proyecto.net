using System;

namespace Domain.ValueObject.OrderStatusHistory;

public sealed record OrderStatusHistoryStatusId
{
    public Guid Value { get; }

    private OrderStatusHistoryStatusId(Guid value)
    {
        Value = value;
    }

    public static OrderStatusHistoryStatusId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("El id debe ser un Guid válido.", nameof(value));

        return new OrderStatusHistoryStatusId(value);
    }

    public override string ToString() => Value.ToString();
}