using System;

namespace Domain.ValueObject.Vehicle;

public sealed record VehicleClientId
{
    public int Value { get; }

    private VehicleClientId(int value)
    {
        Value = value;
    }

    public static VehicleClientId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id del cliente debe ser mayor a 0.", nameof(value));

        return new VehicleClientId(value);
    }

    public override string ToString() => Value.ToString();
}
