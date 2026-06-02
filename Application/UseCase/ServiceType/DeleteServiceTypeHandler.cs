using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using ServiceTypeEntity = Domain.Entities.ServiceType.ServiceType;

namespace Application.UseCase.ServiceType;

public sealed class DeleteServiceTypeHandler : IRequestHandler<DeleteServiceType, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeleteServiceTypeHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        DeleteServiceType request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
