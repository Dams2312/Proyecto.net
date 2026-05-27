using System;

namespace Domain.ValueObject.OrderStatusHistory;

public sealed record OrderStatusHistoryFechaCambio
{
    public DateTime Value { get; }

    private OrderStatusHistoryFechaCambio(DateTime value)
    {
        Value = value;
    }

    public static OrderStatusHistoryFechaCambio Create(DateTime value)
    {
        if (value == default)
            throw new ArgumentException("La fecha de cambio es obligatoria.", nameof(value));

        return new OrderStatusHistoryFechaCambio(value);
    }

    public override string ToString() => Value.ToString("yyyy-MM-dd HH:mm:ss");
}
