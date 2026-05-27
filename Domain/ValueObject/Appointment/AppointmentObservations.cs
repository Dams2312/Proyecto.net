using System;

namespace Domain.ValueObject.Appointment;

public sealed record AppointmentObservations
{
    public string? Value { get; }

    private AppointmentObservations(string? value)
    {
        Value = value;
    }

    public static AppointmentObservations Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return new AppointmentObservations((string?)null);

        value = value.Trim();

        if (value.Length > 2000)
            throw new ArgumentException("Las observaciones no pueden superar los 2000 caracteres.", nameof(value));

        return new AppointmentObservations(value);
    }

    public override string ToString() => Value ?? string.Empty;
}
