using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using UnitMeasureEntity = Domain.Entities.UnitMeasure.UnitMeasure;

namespace Application.UseCase.UnitMeasure;

public sealed class DeleteUnitMeasureHandler : IRequestHandler<DeleteUnitMeasure, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeleteUnitMeasureHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        DeleteUnitMeasure request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
