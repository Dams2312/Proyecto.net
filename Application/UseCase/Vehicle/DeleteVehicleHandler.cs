using Application.Abstractions;
using MediatR;
using VehicleEntity = Domain.Entities.Vehicle.Vehicle;

namespace Application.UseCase.Vehicle;

public sealed class DeleteVehicleHandler : IRequestHandler<DeleteVehicle, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeleteVehicleHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<Unit> Handle(DeleteVehicle request, CancellationToken ct)
    {
        var entity = await _uow.Vehicles.GetByIdAsync(request.Id, ct)
            ?? throw new KeyNotFoundException($"Vehículo con id {request.Id} no encontrado.");

        await _uow.Vehicles.RemoveAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}