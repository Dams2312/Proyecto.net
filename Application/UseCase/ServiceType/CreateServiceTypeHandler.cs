using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.ValueObject.ServiceType;
using MediatR;
using ServiceTypeEntity = Domain.Entities.ServiceType.ServiceType;

namespace Application.UseCase.ServiceType;

public sealed class CreateServiceTypeHandler : IRequestHandler<CreateServiceType, Guid>
{
    private readonly IUnitOfWork _uow;
    public CreateServiceTypeHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<Guid> Handle(CreateServiceType request, CancellationToken ct)
    {
        var name = ServiceTypeName.Create(request.Name);
        var desc = ServiceTypeDescription.Create(request.Description);
        var days = ServiceTypeEstimatedDays.Create(request.EstimatedDays);

        var entity = new ServiceTypeEntity(name, desc, days);
        await _uow.ServiceTypes.AddAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);
        return entity.Id;
    }
}