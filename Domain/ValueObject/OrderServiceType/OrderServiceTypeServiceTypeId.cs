using System;

namespace Domain.ValueObject.OrderServiceType;

public sealed record OrderServiceTypeServiceTypeId
{
    public int Value { get; }

    private OrderServiceTypeServiceTypeId(int value)
    {
        Value = value;
    }

    public static OrderServiceTypeServiceTypeId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id del tipo de servicio debe ser mayor a 0.", nameof(value));

        return new OrderServiceTypeServiceTypeId(value);
    }

    public override string ToString() => Value.ToString();
}
