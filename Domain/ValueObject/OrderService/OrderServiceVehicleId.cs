using System;

namespace Domain.ValueObject.OrderService;

public sealed record OrderServiceVehicleId
{
    public Guid Value { get; }

    private OrderServiceVehicleId(Guid value)
    {
        Value = value;
    }

    public static OrderServiceVehicleId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("El id debe ser un Guid válido.", nameof(value));

        return new OrderServiceVehicleId(value);
    }

    public override string ToString() => Value.ToString();
}