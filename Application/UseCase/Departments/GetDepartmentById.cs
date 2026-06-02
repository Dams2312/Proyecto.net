using System;
using Domain.Entities.Departments;
using MediatR;
using Department = Domain.Entities.Departments.Department;

namespace Application.UseCase.Departament;

public sealed record GetDepartmentById(
    Guid Id
) : IRequest<Department>;

