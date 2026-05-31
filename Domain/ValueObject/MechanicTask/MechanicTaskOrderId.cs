using System;

namespace Domain.ValueObject.MechanicTask;

public sealed record MechanicTaskOrderId
{
    public Guid Value { get; }

    private MechanicTaskOrderId(Guid value)
    {
        Value = value;
    }

    public static MechanicTaskOrderId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("El id de la orden debe ser un Guid válido.", nameof(value));

        return new MechanicTaskOrderId(value);
    }

    public override string ToString() => Value.ToString();
}