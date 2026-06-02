using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using UnitMeasureEntity = Domain.Entities.UnitMeasure.UnitMeasure;

namespace Application.UseCase.UnitMeasure;

public sealed class GetUnitMeasureByIdHandler : IRequestHandler<GetUnitMeasureById, UnitMeasureEntity>
{
    private readonly IUnitOfWork _uow;

    public GetUnitMeasureByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<UnitMeasureEntity> Handle(
        GetUnitMeasureById request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
