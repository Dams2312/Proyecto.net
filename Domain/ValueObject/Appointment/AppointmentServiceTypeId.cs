using System;

namespace Domain.ValueObject.Appointment;

public sealed record AppointmentServiceTypeId
{
    public Guid Value { get; }

    private AppointmentServiceTypeId(Guid value)
    {
        Value = value;
    }

    public static AppointmentServiceTypeId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("El id debe ser un Guid válido.", nameof(value));

        return new AppointmentServiceTypeId(value);
    }

    public override string ToString() => Value.ToString();
}