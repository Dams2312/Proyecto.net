using System;

namespace Domain.ValueObject.OrderServiceType;

public sealed record OrderServiceTypeServiceTypeId
{
    public Guid Value { get; }

    private OrderServiceTypeServiceTypeId(Guid value)
    {
        Value = value;
    }

    public static OrderServiceTypeServiceTypeId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("El id debe ser un Guid válido.", nameof(value));

        return new OrderServiceTypeServiceTypeId(value);
    }

    public override string ToString() => Value.ToString();
}