using System;

namespace Domain.ValueObject.Vehicle;

public sealed record VehicleModelId
{
    public Guid Value { get; }

    private VehicleModelId(Guid value)
    {
        Value = value;
    }

    public static VehicleModelId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("El id del modelo no puede estar vacío.", nameof(value));

        return new VehicleModelId(value);
    }

    public override string ToString() => Value.ToString();
}