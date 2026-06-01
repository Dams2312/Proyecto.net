using System.Collections.Generic;
using Domain.Entities.MechanicTask;
using MediatR;

namespace Application.UseCases.MechanicTask;

public sealed record GetMechanicTasksPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<MechanicTask>>;
