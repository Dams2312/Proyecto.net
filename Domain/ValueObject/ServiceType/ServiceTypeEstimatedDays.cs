using System;

namespace Domain.ValueObject.ServiceType;

public sealed record ServiceTypeEstimatedDays
{
    public int Value { get; }

    private ServiceTypeEstimatedDays(int value)
    {
        Value = value;
    }

    public static ServiceTypeEstimatedDays Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("Los días estimados deben ser mayores a 0.", nameof(value));

        return new ServiceTypeEstimatedDays(value);
    }

    public override string ToString() => Value.ToString();
}
