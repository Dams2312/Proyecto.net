using System;

namespace Domain.ValueObject.OrderMechanic;

public sealed record OrderMechanicFechaAsignacion
{
    public DateOnly Value { get; }

    private OrderMechanicFechaAsignacion(DateOnly value)
    {
        Value = value;
    }

    public static OrderMechanicFechaAsignacion Create(DateOnly value)
    {
        if (value == default)
            throw new ArgumentException("La fecha de asignación es obligatoria.", nameof(value));

        return new OrderMechanicFechaAsignacion(value);
    }

    public override string ToString() => Value.ToString("yyyy-MM-dd");
}
