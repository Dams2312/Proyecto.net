using System;

namespace Domain.ValueObject.OrderMechanic;

public sealed record OrderMechanicOrderId
{
    public Guid Value { get; }

    private OrderMechanicOrderId(Guid value)
    {
        Value = value;
    }

    public static OrderMechanicOrderId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("El id debe ser un Guid válido.", nameof(value));

        return new OrderMechanicOrderId(value);
    }

    public override string ToString() => Value.ToString();
}