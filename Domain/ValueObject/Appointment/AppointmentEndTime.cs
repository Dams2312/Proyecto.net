using System;

namespace Domain.ValueObject.Appointment;

public sealed record AppointmentEndTime
{
    public TimeOnly Value { get; }

    private AppointmentEndTime(TimeOnly value)
    {
        Value = value;
    }

    public static AppointmentEndTime Create(TimeOnly value)
    {
        if (value == default)
            throw new ArgumentException("La hora de fin es obligatoria.", nameof(value));

        return new AppointmentEndTime(value);
    }

    public override string ToString() => Value.ToString("HH:mm:ss");
}
