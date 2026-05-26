using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObject.Role;

public class RoleName
{
    public string Value { get; }
    private RoleName(string value)
    {
        Value = value;
    }
    public static RoleName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El nombre del rol es obligatorio.", nameof(value));

        var normalized = value.Trim().ToLowerInvariant();

        if (normalized.Length > 50)
            throw new ArgumentException("El nombre del rol no puede tener más de 50 caracteres.", nameof(value));

        return new RoleName(normalized);
    }
}
