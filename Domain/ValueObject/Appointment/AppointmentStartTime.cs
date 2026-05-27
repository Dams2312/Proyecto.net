using System;

namespace Domain.ValueObject.Appointment;

public sealed record AppointmentStartTime
{
    public TimeOnly Value { get; }

    private AppointmentStartTime(TimeOnly value)
    {
        Value = value;
    }

    public static AppointmentStartTime Create(TimeOnly value)
    {
        if (value == default)
            throw new ArgumentException("La hora de inicio es obligatoria.", nameof(value));

        return new AppointmentStartTime(value);
    }

    public override string ToString() => Value.ToString("HH:mm:ss");
}
