using System;

namespace Domain.ValueObject.MechanicTask;

public sealed record MechanicTaskMechanicId
{
    public Guid Value { get; }

    private MechanicTaskMechanicId(Guid value)
    {
        Value = value;
    }

    public static MechanicTaskMechanicId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("El id debe ser un Guid válido.", nameof(value));

        return new MechanicTaskMechanicId(value);
    }

    public override string ToString() => Value.ToString();
}