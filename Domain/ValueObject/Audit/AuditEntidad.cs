using System;

namespace Domain.ValueObject.Audit;

public sealed record AuditEntidad
{
    public string Value { get; }

    private AuditEntidad(string value)
    {
        Value = value;
    }

    public static AuditEntidad Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("La entidad auditada es obligatoria.", nameof(value));

        value = value.Trim();

        if (value.Length > 80)
            throw new ArgumentException("El nombre de la entidad no puede superar los 80 caracteres.", nameof(value));

        return new AuditEntidad(value);
    }

    public override string ToString() => Value;
}
