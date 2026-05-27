using System;

namespace Domain.ValueObject.MechanicTask;

public sealed record MechanicTaskStatus
{
    public string Value { get; }

    private MechanicTaskStatus(string value)
    {
        Value = value;
    }

    public static MechanicTaskStatus Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El estado es obligatorio.", nameof(value));

        var normalized = value.Trim().ToLowerInvariant();

        if (normalized is not ("pendiente" or "en_progreso" or "completada"))
            throw new ArgumentException("El estado no es válido.", nameof(value));

        return new MechanicTaskStatus(normalized);
    }

    public override string ToString() => Value;
}
