using Application.Abstractions;
using Domain.ValueObject.ServiceType;
using MediatR;
using ServiceTypeEntity = Domain.Entities.ServiceType.ServiceType;

namespace Application.UseCase.ServiceType;

public sealed class UpdateServiceTypeHandler : IRequestHandler<UpdateServiceType, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateServiceTypeHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<Unit> Handle(UpdateServiceType request, CancellationToken ct)
    {
        var entity = await _uow.ServiceTypes.GetByIdAsync(request.Id, ct)
            ?? throw new KeyNotFoundException($"Tipo de servicio con id {request.Id} no encontrado.");

        entity.UpdateName(ServiceTypeName.Create(request.Name));
        entity.UpdateDescription(ServiceTypeDescription.Create(request.Description));
        entity.UpdateEstimatedDays(ServiceTypeEstimatedDays.Create(request.EstimatedDays));

        await _uow.ServiceTypes.UpdateAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}