using System;

namespace Domain.ValueObject.OrderService;

public sealed record OrderServiceFechaIngreso
{
    public DateOnly Value { get; }

    private OrderServiceFechaIngreso(DateOnly value)
    {
        Value = value;
    }

    public static OrderServiceFechaIngreso Create(DateOnly value)
    {
        if (value == default)
            throw new ArgumentException("La fecha de ingreso es obligatoria.", nameof(value));

        return new OrderServiceFechaIngreso(value);
    }

    public override string ToString() => Value.ToString("yyyy-MM-dd");
}
