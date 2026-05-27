using System;

namespace Domain.ValueObject.Audit;

public sealed record AuditFecha
{
    public DateTime Value { get; }

    private AuditFecha(DateTime value)
    {
        Value = value;
    }

    public static AuditFecha Create(DateTime value)
    {
        if (value == default)
            throw new ArgumentException("La fecha de auditoría es obligatoria.", nameof(value));

        return new AuditFecha(value);
    }

    public override string ToString() => Value.ToString("yyyy-MM-dd HH:mm:ss");
}
