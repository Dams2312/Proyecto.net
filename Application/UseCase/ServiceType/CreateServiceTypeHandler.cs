using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using ServiceTypeEntity = Domain.Entities.ServiceType.ServiceType;

namespace Application.UseCase.ServiceType;

public sealed class CreateServiceTypeHandler : IRequestHandler<CreateServiceType, Guid>
{
    private readonly IUnitOfWork _uow;

    public CreateServiceTypeHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Guid> Handle(
        CreateServiceType request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
