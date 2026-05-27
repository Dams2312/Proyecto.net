using System;

namespace Domain.ValueObject.MechanicTask;

public sealed record MechanicTaskMechanicId
{
    public int Value { get; }

    private MechanicTaskMechanicId(int value)
    {
        Value = value;
    }

    public static MechanicTaskMechanicId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El id del mecánico debe ser mayor a 0.", nameof(value));

        return new MechanicTaskMechanicId(value);
    }

    public override string ToString() => Value.ToString();
}
