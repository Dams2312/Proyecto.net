using System;

namespace Domain.ValueObject.MechanicTask;

public sealed record MechanicTaskHourlyCost
{
    public decimal Value { get; }

    private MechanicTaskHourlyCost(decimal value)
    {
        Value = value;
    }

    public static MechanicTaskHourlyCost Create(decimal value)
    {
        if (value < 0)
            throw new ArgumentException("El costo por hora no puede ser negativo.", nameof(value));

        return new MechanicTaskHourlyCost(value);
    }

    public override string ToString() => Value.ToString("0.00");
}
