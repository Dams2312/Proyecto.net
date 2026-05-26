using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObject.Department;

public sealed record DepartmentCode
{
    public string Value { get; }

    private DepartmentCode(string value)
    {
        Value = value;
    }

    public static DepartmentCode Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("El código del departamento es obligatorio.", nameof(value));

        var normalized = value.Trim().ToUpperInvariant();

        if (normalized.Length != 4)
            throw new ArgumentException("El código del departamento debe tener exactamente 4 caracteres.", nameof(value));

        return new DepartmentCode(normalized);
    }

    public override string ToString() => Value;
}
