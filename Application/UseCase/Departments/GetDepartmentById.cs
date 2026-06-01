using System;
using Domain.Entities.Departments;
using MediatR;

namespace Application.UseCases.Departments;

public sealed record GetDepartmentById(
    Guid Id
) : IRequest<Department>;
