using Domain.common;

namespace Domain.Entities.Citys;

public sealed class City : BaseEntity<Guid>
{
    public string Name { get; private set; }

    public Guid DepartmentId { get; private set; }

    public string Code { get; private set; }

    private City() { }

    public City(
        string name,
        Guid departmentId,
        string code)
    {
        Name = name;
        DepartmentId = departmentId;
        Code = code;
    }

    public void UpdateName(string name)
    {
        Name = name;
    }

    public void UpdateDepartment(Guid departmentId)
    {
        DepartmentId = departmentId;
    }

    public void UpdateCode(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
            throw new ArgumentException("El código de la ciudad es obligatorio.", nameof(code));

        Code = code;
    }
}