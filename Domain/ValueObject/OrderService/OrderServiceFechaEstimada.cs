using System;

namespace Domain.ValueObject.OrderService;

public sealed record OrderServiceFechaEstimada
{
    public DateOnly? Value { get; }

    private OrderServiceFechaEstimada(DateOnly? value)
    {
        Value = value;
    }

    public static OrderServiceFechaEstimada Create(DateOnly? value)
    {
        return new OrderServiceFechaEstimada(value);
    }

    public override string ToString() => Value?.ToString("yyyy-MM-dd") ?? string.Empty;
}
