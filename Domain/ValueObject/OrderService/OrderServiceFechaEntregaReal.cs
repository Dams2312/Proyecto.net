using System;

namespace Domain.ValueObject.OrderService;

public sealed record OrderServiceFechaEntregaReal
{
    public DateOnly? Value { get; }

    private OrderServiceFechaEntregaReal(DateOnly? value)
    {
        Value = value;
    }

    public static OrderServiceFechaEntregaReal Create(DateOnly? value)
    {
        return new OrderServiceFechaEntregaReal(value);
    }

    public override string ToString() => Value?.ToString("yyyy-MM-dd") ?? string.Empty;
}
