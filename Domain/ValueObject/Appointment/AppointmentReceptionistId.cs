using System;

namespace Domain.ValueObject.Appointment;

public sealed record AppointmentReceptionistId
{
    public Guid Value { get; }

    private AppointmentReceptionistId(Guid value)
    {
        Value = value;
    }

    public static AppointmentReceptionistId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("El id debe ser un Guid válido.", nameof(value));

        return new AppointmentReceptionistId(value);
    }

    public override string ToString() => Value.ToString();
}