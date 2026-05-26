using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObject.Department;

public sealed record DepartmentCountryId
{
    public int Value { get; }
    private DepartmentCountryId(int value)
    {
        Value = value;
    }
    public static DepartmentCountryId Create(int value)
    {
        if (value <= 0)
            throw new ArgumentException("El ID del país debe ser un número positivo.", nameof(value));

        return new DepartmentCountryId(value);
    }
    public override string ToString() => Value.ToString();
}
