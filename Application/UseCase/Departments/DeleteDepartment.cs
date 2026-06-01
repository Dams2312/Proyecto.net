using System;
using MediatR;

namespace Application.UseCases.Departments;

public sealed record DeleteDepartment(
    Guid Id
) : IRequest<Unit>;
