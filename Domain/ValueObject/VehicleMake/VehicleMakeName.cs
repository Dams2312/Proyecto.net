using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObject.VehicleMake;

public sealed record VehicleMakeName
{
    public string Value { get; }
    private VehicleMakeName(string value)
    {
        Value = value;
    }
    public static VehicleMakeName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El nombre de la marca de vehículo es obligatorio.", nameof(value));

        var normalized = value.Trim().ToLowerInvariant();

        if (normalized.Length < 2 || normalized.Length > 100)
            throw new ArgumentException("El nombre de la marca de vehículo debe tener entre 2 y 100 caracteres.", nameof(value));

        return new VehicleMakeName(normalized);
    }
}
