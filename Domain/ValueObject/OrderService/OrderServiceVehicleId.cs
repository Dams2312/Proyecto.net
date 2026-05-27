using System;

namespace Domain.ValueObject.OrderService;

public sealed record OrderServiceVehicleId
{
    public int Value { get; }

    private OrderServiceVehicleId(int value)
    {
        Value = value;
    }

    public static OrderServiceVehicleId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id del vehículo debe ser mayor a 0.", nameof(value));

        return new OrderServiceVehicleId(value);
    }

    public override string ToString() => Value.ToString();
}
