using System;

namespace Domain.ValueObject.Vehicle;

public sealed record VehicleYear
{
    public int Value { get; }

    private VehicleYear(int value)
    {
        Value = value;
    }

    public static VehicleYear Create(int value)
    {
        if (value < 1900)
            throw new ArgumentException("El año del vehículo debe ser mayor o igual a 1900.", nameof(value));

        var currentYear = DateTime.UtcNow.Year;
        if (value > currentYear + 1)
            throw new ArgumentException("El año del vehículo no puede ser mayor al año actual más uno.", nameof(value));

        return new VehicleYear(value);
    }

    public override string ToString() => Value.ToString();
}
