using System;
using MediatR;
using Department = Domain.Entities.Departments.Department;

namespace Application.UseCase.Departament;

public sealed record UpdateDepartment(
    Guid Id,
    string Code,
    string Name,
    Guid CountryId
) : IRequest<Unit>;

