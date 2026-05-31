using System;

namespace Domain.ValueObject.MechanicTask;

public sealed record MechanicTaskServiceTypeId
{
    public Guid Value { get; }

    private MechanicTaskServiceTypeId(Guid value)
    {
        Value = value;
    }

    public static MechanicTaskServiceTypeId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("El id del tipo de servicio debe ser un Guid válido.", nameof(value));

        return new MechanicTaskServiceTypeId(value);
    }

    public override string ToString() => Value.ToString();
}