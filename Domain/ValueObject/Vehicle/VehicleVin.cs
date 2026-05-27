using System;

namespace Domain.ValueObject.Vehicle;

public sealed record VehicleVin
{
    public string Value { get; }

    private VehicleVin(string value)
    {
        Value = value;
    }

    public static VehicleVin Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El VIN es obligatorio.", nameof(value));

        value = value.Trim().ToUpperInvariant();

        if (value.Length != 17)
            throw new ArgumentException("El VIN debe tener exactamente 17 caracteres.", nameof(value));

        return new VehicleVin(value);
    }

    public override string ToString() => Value;
}
