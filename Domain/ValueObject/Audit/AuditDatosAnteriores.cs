using System;

namespace Domain.ValueObject.Audit;

public sealed record AuditDatosAnteriores
{
    public string? Value { get; }

    private AuditDatosAnteriores(string? value)
    {
        Value = value;
    }

    public static AuditDatosAnteriores Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return new AuditDatosAnteriores((string?)null);

        value = value.Trim();

        if (value.Length > 4000)
            throw new ArgumentException("Los datos anteriores no pueden superar los 4000 caracteres.", nameof(value));

        return new AuditDatosAnteriores(value);
    }

    public override string ToString() => Value ?? string.Empty;
}
