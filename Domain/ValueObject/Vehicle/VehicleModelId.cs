using System;

namespace Domain.ValueObject.Vehicle;

public sealed record VehicleModelId
{
    public int Value { get; }

    private VehicleModelId(int value)
    {
        Value = value;
    }

    public static VehicleModelId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id del modelo debe ser mayor a 0.", nameof(value));

        return new VehicleModelId(value);
    }

    public override string ToString() => Value.ToString();
}
