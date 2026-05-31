using System;

namespace Domain.ValueObject.Vehicle;

public sealed record VehicleClientId
{
    public Guid Value { get; }  // ✅ Cambia int → Guid

    private VehicleClientId(Guid value)
    {
        Value = value;
    }

    public static VehicleClientId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("El id del cliente no puede ser vacío.", nameof(value));

        return new VehicleClientId(value);
    }

    public override string ToString() => Value.ToString();
}