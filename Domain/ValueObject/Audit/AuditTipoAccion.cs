using System;

namespace Domain.ValueObject.Audit;

public sealed record AuditTipoAccion
{
    public string Value { get; }

    private AuditTipoAccion(string value)
    {
        Value = value;
    }

    public static AuditTipoAccion Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El tipo de acción es obligatorio.", nameof(value));

        value = value.Trim().ToUpperInvariant();

        if (value != "INSERT" && value != "UPDATE" && value != "DELETE" && value != "LOGIN" && value != "LOGOUT")
            throw new ArgumentException("El tipo de acción debe ser INSERT, UPDATE, DELETE, LOGIN o LOGOUT.", nameof(value));

        return new AuditTipoAccion(value);
    }

    public override string ToString() => Value;
}
