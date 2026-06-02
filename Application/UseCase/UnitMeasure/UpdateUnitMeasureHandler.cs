using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using UnitMeasureEntity = Domain.Entities.UnitMeasure.UnitMeasure;

namespace Application.UseCase.UnitMeasure;

public sealed class UpdateUnitMeasureHandler : IRequestHandler<UpdateUnitMeasure, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateUnitMeasureHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        UpdateUnitMeasure request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
