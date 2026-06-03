using System;
using MediatR;

namespace Application.UseCase.UnitMeasure;

public sealed record UpdateUnitMeasure(
    Guid Id,
    string Name,
    string Abbreviation
) : IRequest<Unit>;
