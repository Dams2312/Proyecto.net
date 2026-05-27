using System;

namespace Domain.ValueObject.MechanicTask;

public sealed record MechanicTaskFechaInicio
{
    public DateTime? Value { get; }

    private MechanicTaskFechaInicio(DateTime? value)
    {
        Value = value;
    }

    public static MechanicTaskFechaInicio Create(DateTime? value)
    {
        return new MechanicTaskFechaInicio(value);
    }

    public override string ToString() => Value?.ToString("yyyy-MM-dd HH:mm:ss") ?? string.Empty;
}
