using System;

namespace Domain.ValueObject.Audit;

public sealed record AuditDatosNuevos
{
    public string? Value { get; }

    private AuditDatosNuevos(string? value)
    {
        Value = value;
    }

    public static AuditDatosNuevos Create(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return new AuditDatosNuevos((string?)null);

        value = value.Trim();

        if (value.Length > 4000)
            throw new ArgumentException("Los datos nuevos no pueden superar los 4000 caracteres.", nameof(value));

        return new AuditDatosNuevos(value);
    }

    public override string ToString() => Value ?? string.Empty;
}
