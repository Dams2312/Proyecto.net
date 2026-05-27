using System;

namespace Domain.ValueObject.MechanicTask;

public sealed record MechanicTaskHoursWorked
{
    public decimal Value { get; }

    private MechanicTaskHoursWorked(decimal value)
    {
        Value = value;
    }

    public static MechanicTaskHoursWorked Create(decimal value)
    {
        if (value < 0)
            throw new ArgumentException("Las horas trabajadas no pueden ser negativas.", nameof(value));

        return new MechanicTaskHoursWorked(value);
    }

    public override string ToString() => Value.ToString("0.00");
}
