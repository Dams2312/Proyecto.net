using System.Collections.Generic;
using Domain.Entities.Departments;
using MediatR;
using Department = Domain.Entities.Departments.Department;

namespace Application.UseCase.Departament;

public sealed record GetDepartmentsPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<Department>>;

