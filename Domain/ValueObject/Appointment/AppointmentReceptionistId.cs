using System;

namespace Domain.ValueObject.Appointment;

public sealed record AppointmentReceptionistId
{
    public int Value { get; }

    private AppointmentReceptionistId(int value)
    {
        Value = value;
    }

    public static AppointmentReceptionistId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id del recepcionista debe ser mayor a 0.", nameof(value));

        return new AppointmentReceptionistId(value);
    }

    public override string ToString() => Value.ToString();
}
