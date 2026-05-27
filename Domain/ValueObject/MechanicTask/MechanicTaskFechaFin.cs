using System;

namespace Domain.ValueObject.MechanicTask;

public sealed record MechanicTaskFechaFin
{
    public DateTime? Value { get; }

    private MechanicTaskFechaFin(DateTime? value)
    {
        Value = value;
    }

    public static MechanicTaskFechaFin Create(DateTime? value)
    {
        return new MechanicTaskFechaFin(value);
    }

    public override string ToString() => Value?.ToString("yyyy-MM-dd HH:mm:ss") ?? string.Empty;
}
