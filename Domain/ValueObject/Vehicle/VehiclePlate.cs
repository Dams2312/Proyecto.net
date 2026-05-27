using System;

namespace Domain.ValueObject.Vehicle;

public sealed record VehiclePlate
{
    public string Value { get; }

    private VehiclePlate(string value)
    {
        Value = value;
    }

    public static VehiclePlate Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("La placa es obligatoria.", nameof(value));

        value = value.Trim().ToUpperInvariant();

        if (value.Length > 10)
            throw new ArgumentException("La placa no puede superar los 10 caracteres.", nameof(value));

        return new VehiclePlate(value);
    }

    public override string ToString() => Value;
}
