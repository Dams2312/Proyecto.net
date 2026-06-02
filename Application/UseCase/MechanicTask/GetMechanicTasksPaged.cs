using System.Collections.Generic;
using MediatR;
using MechanicTaskEntity = Domain.Entities.MechanicTask.MechanicTask;

namespace Application.UseCase.MechanicTask;

public sealed record GetMechanicTasksPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<MechanicTaskEntity>>;

