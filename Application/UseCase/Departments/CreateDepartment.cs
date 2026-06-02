using MediatR;
using Department = Domain.Entities.Departments.Department;

namespace Application.UseCase.Departament;

public sealed record CreateDepartment(
    string Code,
    string Name,
    Guid CountryId
) : IRequest<Guid>;

