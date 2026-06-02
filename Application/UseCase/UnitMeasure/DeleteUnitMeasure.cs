using System;
using MediatR;
using UnitMeasureEntity = Domain.Entities.UnitMeasure.UnitMeasure;

namespace Application.UseCase.UnitMeasure;

public sealed record DeleteUnitMeasure(Guid Id) : IRequest<Unit>;
