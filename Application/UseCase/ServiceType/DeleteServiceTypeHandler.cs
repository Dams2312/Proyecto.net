using Application.Abstractions;
using MediatR;
using ServiceTypeEntity = Domain.Entities.ServiceType.ServiceType;

namespace Application.UseCase.ServiceType;

public sealed class DeleteServiceTypeHandler : IRequestHandler<DeleteServiceType, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeleteServiceTypeHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<Unit> Handle(DeleteServiceType request, CancellationToken ct)
    {
        var entity = await _uow.ServiceTypes.GetByIdAsync(request.Id, ct)
            ?? throw new KeyNotFoundException($"Tipo de servicio con id {request.Id} no encontrado.");

        await _uow.ServiceTypes.RemoveAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}