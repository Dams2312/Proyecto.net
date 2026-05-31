using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObject.VehicleModel;

public sealed record VehicleModelMake
{
    public Guid Value { get; }

    private VehicleModelMake(Guid value)
    {
        Value = value;
    }

    public static VehicleModelMake Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("El id debe ser un Guid válido.", nameof(value));

        return new VehicleModelMake(value);
    }

    public override string ToString() => Value.ToString();
}