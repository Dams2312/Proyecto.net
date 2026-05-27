using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObject.VehicleModel;

public sealed record VehicleModelMake
{
    public int Value { get; }

    private VehicleModelMake(int value)
    {
        Value = value;
    }

    public static VehicleModelMake Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id de la marca debe ser mayor a 0.", nameof(value));

        return new VehicleModelMake(value);
    }

    public override string ToString() => Value.ToString();
}
