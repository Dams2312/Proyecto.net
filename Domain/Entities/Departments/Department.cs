using System;
using Domain.common;
using Domain.ValueObject.Department;

namespace Domain.Entities.Departments;

public sealed class Department : BaseEntity<Guid>
{
    public DepartmentCode Code { get; private set; }

    public DepartmentName Name { get; private set; }

    // FK COMO GUID
    public Guid CountryId { get; private set; }

    private Department() { }

    public Department(
        DepartmentCode code,
        DepartmentName name,
        Guid countryId)
    {
        Code = code ?? throw new ArgumentNullException(nameof(code));
        Name = name ?? throw new ArgumentNullException(nameof(name));

        if (countryId == Guid.Empty)
            throw new ArgumentException("El id del país es obligatorio.", nameof(countryId));

        CountryId = countryId;
    }

    public void UpdateCode(DepartmentCode code)
    {
        Code = code ?? throw new ArgumentNullException(nameof(code));
    }

    public void UpdateName(DepartmentName name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public void UpdateCountry(Guid countryId)
    {
        if (countryId == Guid.Empty)
            throw new ArgumentException("El id del país es obligatorio.", nameof(countryId));

        CountryId = countryId;
    }
}