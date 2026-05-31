using System;

namespace Domain.ValueObject.OrderMechanic;

public sealed record OrderMechanicMechanicId
{
    public Guid Value { get; }

    private OrderMechanicMechanicId(Guid value)
    {
        Value = value;
    }

    public static OrderMechanicMechanicId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("El id debe ser un Guid válido.", nameof(value));

        return new OrderMechanicMechanicId(value);
    }

    public override string ToString() => Value.ToString();
}