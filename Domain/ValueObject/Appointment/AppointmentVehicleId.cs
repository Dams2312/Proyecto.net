using System;

namespace Domain.ValueObject.Appointment;

public sealed record AppointmentVehicleId
{
    public Guid Value { get; }

    private AppointmentVehicleId(Guid value)
    {
        Value = value;
    }

    public static AppointmentVehicleId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("El id debe ser un Guid válido.", nameof(value));

        return new AppointmentVehicleId(value);
    }

    public override string ToString() => Value.ToString();
}