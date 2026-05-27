using System;

namespace Domain.ValueObject.Audit;

public sealed record AuditIpOrigen
{
    public string? Value { get; }

    private AuditIpOrigen(string? value)
    {
        Value = value;
    }

    public static AuditIpOrigen Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return new AuditIpOrigen((string?)null);

        value = value.Trim();

        if (value.Length > 45)
            throw new ArgumentException("La IP de origen no puede superar los 45 caracteres.", nameof(value));

        return new AuditIpOrigen(value);
    }

    public override string ToString() => Value ?? string.Empty;
}
