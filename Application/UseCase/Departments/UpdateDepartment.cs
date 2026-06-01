using System;
using MediatR;

namespace Application.UseCases.Departments;

public sealed record UpdateDepartment(
    Guid Id,
    string Code,
    string Name,
    Guid CountryId
) : IRequest<Unit>;
