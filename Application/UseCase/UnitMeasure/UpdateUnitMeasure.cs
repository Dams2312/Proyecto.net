using System;
using MediatR;
using UnitMeasureEntity = Domain.Entities.UnitMeasure.UnitMeasure;

namespace Application.UseCase.UnitMeasure;

public sealed record UpdateUnitMeasure(
    Guid Id,
    Guid CountryId,
    string Name,
    string Code
) : IRequest<Unit>;
