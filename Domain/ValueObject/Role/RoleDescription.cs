using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObject.Role;

public class RoleDescription
{
    public string Value { get; }
    private RoleDescription(string value)
    {
        Value = value;
    }
    public static RoleDescription Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("La descripción del rol es obligatoria.", nameof(value));

        var normalized = value.Trim();

        if (normalized.Length > 200)
            throw new ArgumentException("La descripción del rol no puede tener más de 200 caracteres.", nameof(value));

        return new RoleDescription(normalized);
    }
    public override string ToString() => Value;
}
