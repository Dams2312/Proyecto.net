using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObject.VehicleModel;

public sealed record VehicleModelYearTo
{
    public short? Value { get; }

    private VehicleModelYearTo(short? value)
    {
        Value = value;
    }

    public static VehicleModelYearTo Create(short? value)
    {
        if (value is not null)
        {
            if (value < 1900)
                throw new ArgumentException("El año hasta no puede ser menor a 1900.", nameof(value));

            if (value > DateTime.UtcNow.Year + 1)
                throw new ArgumentException("El año hasta no es válido.", nameof(value));
        }

        return new VehicleModelYearTo(value);
    }

    public override string ToString() => Value?.ToString() ?? string.Empty;
}

