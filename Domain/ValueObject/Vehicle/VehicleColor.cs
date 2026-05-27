using System;

namespace Domain.ValueObject.Vehicle;

public sealed record VehicleColor
{
    public string Value { get; }

    private VehicleColor(string value)
    {
        Value = value;
    }

    public static VehicleColor Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return new VehicleColor(string.Empty);

        value = value.Trim();

        if (value.Length > 50)
            throw new ArgumentException("El color no puede superar los 50 caracteres.", nameof(value));

        return new VehicleColor(value);
    }

    public override string ToString() => Value;
}
