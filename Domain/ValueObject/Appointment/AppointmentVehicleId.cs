using System;

namespace Domain.ValueObject.Appointment;

public sealed record AppointmentVehicleId
{
    public int Value { get; }

    private AppointmentVehicleId(int value)
    {
        Value = value;
    }

    public static AppointmentVehicleId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id del vehículo debe ser mayor a 0.", nameof(value));

        return new AppointmentVehicleId(value);
    }

    public override string ToString() => Value.ToString();
}
