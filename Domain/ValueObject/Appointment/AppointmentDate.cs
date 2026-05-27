using System;

namespace Domain.ValueObject.Appointment;

public sealed record AppointmentDate
{
    public DateOnly Value { get; }

    private AppointmentDate(DateOnly value)
    {
        Value = value;
    }

    public static AppointmentDate Create(DateOnly value)
    {
        if (value == default)
            throw new ArgumentException("La fecha de la cita es obligatoria.", nameof(value));

        return new AppointmentDate(value);
    }

    public override string ToString() => Value.ToString("yyyy-MM-dd");
}
