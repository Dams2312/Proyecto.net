using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using ServiceTypeEntity = Domain.Entities.ServiceType.ServiceType;

namespace Application.UseCase.ServiceType;

public sealed class UpdateServiceTypeHandler : IRequestHandler<UpdateServiceType, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateServiceTypeHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        UpdateServiceType request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
