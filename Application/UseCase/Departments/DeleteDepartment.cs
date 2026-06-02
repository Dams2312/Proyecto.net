using System;
using MediatR;
using Department = Domain.Entities.Departments.Department;

namespace Application.UseCase.Departament;

public sealed record DeleteDepartment(
    Guid Id
) : IRequest<Unit>;

