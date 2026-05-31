using System;

namespace Domain.ValueObject.OrderServiceType;

public sealed record OrderServiceTypeOrderId
{
    public Guid Value { get; }

    private OrderServiceTypeOrderId(Guid value)
    {
        Value = value;
    }

    public static OrderServiceTypeOrderId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("El id debe ser un Guid válido.", nameof(value));

        return new OrderServiceTypeOrderId(value);
    }

    public override string ToString() => Value.ToString();
}