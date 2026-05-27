using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObject.VehicleModel;

public sealed record VehicleModelYearFrom
{
    public short Value { get; }

    private VehicleModelYearFrom(short value)
    {
        Value = value;
    }

    public static VehicleModelYearFrom Create(short value)
    {
        if (value < 1900)
            throw new ArgumentException(
                "El año desde no puede ser menor a 1900.",
                nameof(value));

        if (value > DateTime.UtcNow.Year + 1)
            throw new ArgumentException(
                "El año desde no es válido.",
                nameof(value));

        return new VehicleModelYearFrom(value);
    }

    public override string ToString() => Value.ToString();
}
