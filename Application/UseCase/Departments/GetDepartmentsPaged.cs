using System.Collections.Generic;
using Domain.Entities.Departments;
using MediatR;

namespace Application.UseCases.Departments;

public sealed record GetDepartmentsPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<Department>>;
