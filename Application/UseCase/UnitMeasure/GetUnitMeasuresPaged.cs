using System.Collections.Generic;
using MediatR;
using UnitMeasureEntity = Domain.Entities.UnitMeasure.UnitMeasure;

namespace Application.UseCase.UnitMeasure;

public sealed record GetUnitMeasuresPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<UnitMeasureEntity>>;
