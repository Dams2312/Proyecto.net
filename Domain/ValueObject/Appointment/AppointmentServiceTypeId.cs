using System;

namespace Domain.ValueObject.Appointment;

public sealed record AppointmentServiceTypeId
{
    public int Value { get; }

    private AppointmentServiceTypeId(int value)
    {
        Value = value;
    }

    public static AppointmentServiceTypeId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id del tipo de servicio debe ser mayor a 0.", nameof(value));

        return new AppointmentServiceTypeId(value);
    }

    public override string ToString() => Value.ToString();
}
