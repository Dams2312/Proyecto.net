using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObject.Department;

public sealed record DepartmentName
{
    public string Value { get; }

    private DepartmentName(string value)
    {
        Value = value;
    }

    public static DepartmentName Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El nombre del departamento es obligatorio.", nameof(value));

        var normalized = value.Trim().ToLowerInvariant();

        if (normalized.Length < 2 || normalized.Length >= 100)
            throw new ArgumentException("El nombre del departamento debe tener entre 2 y 100 caracteres.", nameof(value));

        return new DepartmentName(normalized);
    }

    public override string ToString() => Value;
}
