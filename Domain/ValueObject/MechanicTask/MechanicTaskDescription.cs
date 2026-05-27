using System;

namespace Domain.ValueObject.MechanicTask;

public sealed record MechanicTaskDescription
{
    public string Value { get; }

    private MechanicTaskDescription(string value)
    {
        Value = value;
    }

    public static MechanicTaskDescription Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("La descripción es obligatoria.", nameof(value));

        value = value.Trim();

        if (value.Length > 2000)
            throw new ArgumentException("La descripción no puede superar los 2000 caracteres.", nameof(value));

        return new MechanicTaskDescription(value);
    }

    public override string ToString() => Value;
}
