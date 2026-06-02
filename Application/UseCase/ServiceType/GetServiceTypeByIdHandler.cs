using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using ServiceTypeEntity = Domain.Entities.ServiceType.ServiceType;

namespace Application.UseCase.ServiceType;

public sealed class GetServiceTypeByIdHandler : IRequestHandler<GetServiceTypeById, ServiceTypeEntity>
{
    private readonly IUnitOfWork _uow;

    public GetServiceTypeByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<ServiceTypeEntity> Handle(
        GetServiceTypeById request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
