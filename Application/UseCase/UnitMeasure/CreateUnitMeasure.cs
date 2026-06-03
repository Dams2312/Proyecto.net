using System;
using MediatR;

namespace Application.UseCase.UnitMeasure;

public sealed record CreateUnitMeasure(
    string Name,
    string Abbreviation
) : IRequest<Guid>;
