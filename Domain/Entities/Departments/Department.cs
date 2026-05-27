using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.common;
using Domain.ValueObject.Department;

namespace Domain.Entities.Departments;

public sealed class Department : BaseEntity<Guid>
{
    public DepartmentCode Code { get; private set; }
    public DepartmentName Name { get; private set; }
    public DepartmentCountryId CountryId { get; private set; }
    private Department() { }
    public Department(DepartmentCode code, DepartmentName name, DepartmentCountryId countryId)
    {
        Code = code ?? throw new ArgumentNullException(nameof(code));
        Name = name ?? throw new ArgumentNullException(nameof(name));
        CountryId = countryId ?? throw new ArgumentNullException(nameof(countryId));
    }
    public void UpdateCode(DepartmentCode code)
    {
        Code = code ?? throw new ArgumentNullException(nameof(code));
    }

    public void UpdateName(DepartmentName name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public void UpdateCountry(DepartmentCountryId countryId)
    {
        CountryId = countryId ?? throw new ArgumentNullException(nameof(countryId));
    }
}
