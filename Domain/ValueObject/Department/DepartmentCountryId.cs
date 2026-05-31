using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ValueObject.Department;

public sealed record DepartmentCountryId
{
    public Guid Value { get; }
    private DepartmentCountryId(Guid value)
    {
        Value = value;
    }
    public static DepartmentCountryId Create(Guid value)
    {
        if (value == Guid.Empty)
            throw new ArgumentException("El id debe ser un Guid válido.", nameof(value));

        return new DepartmentCountryId(value);
    }
    public override string ToString() => Value.ToString();
}