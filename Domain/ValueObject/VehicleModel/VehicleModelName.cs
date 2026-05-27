using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObject.VehicleModel;

public sealed record VehicleModelName
{
    public string Value { get; }

    private VehicleModelName(string value)
    {
        Value = value;
    }

    public static VehicleModelName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El nombre del modelo es obligatorio.", nameof(value));

        value = value.Trim();

        if (value.Length > 80)
            throw new ArgumentException("El nombre del modelo no puede superar los 80 caracteres.", nameof(value));

        if (value.Length < 2)
            throw new ArgumentException("El nombre del modelo debe tener al menos 2 caracteres.", nameof(value));

        return new VehicleModelName(value);
    }

    public override string ToString() => Value;
}
