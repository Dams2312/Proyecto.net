using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using UnitMeasureEntity = Domain.Entities.UnitMeasure.UnitMeasure;

namespace Application.UseCase.UnitMeasure;

public sealed class CreateUnitMeasureHandler : IRequestHandler<CreateUnitMeasure, Guid>
{
    private readonly IUnitOfWork _uow;

    public CreateUnitMeasureHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Guid> Handle(
        CreateUnitMeasure request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
