using System;

namespace Domain.ValueObject.Appointment;

public sealed record AppointmentStatus
{
    public string Value { get; }

    private AppointmentStatus(string value)
    {
        Value = value;
    }

    public static AppointmentStatus Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El estado de la cita es obligatorio.", nameof(value));

        var normalized = value.Trim().ToLowerInvariant();

        if (normalized is not ("pendiente" or "confirmada" or "cancelada" or "completada"))
            throw new ArgumentException("El estado de la cita no es válido.", nameof(value));

        return new AppointmentStatus(normalized);
    }

    public override string ToString() => Value;
}
