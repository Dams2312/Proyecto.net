using Application.Abstractions;
using Domain.ValueObject.Vehicle;
using MediatR;
using VehicleEntity = Domain.Entities.Vehicle.Vehicle;

namespace Application.UseCase.Vehicle;

public sealed class UpdateVehicleHandler : IRequestHandler<UpdateVehicle, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateVehicleHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<Unit> Handle(UpdateVehicle request, CancellationToken ct)
    {
        var entity = await _uow.Vehicles.GetByIdAsync(request.Id, ct)
            ?? throw new KeyNotFoundException($"Vehículo con id {request.Id} no encontrado.");

        entity.UpdateClientId(request.ClientId);
        entity.UpdateModelId(request.ModelId);
        entity.UpdateVin(VehicleVin.Create(request.Vin));
        entity.UpdatePlate(VehiclePlate.Create(request.Plate));
        entity.UpdateYear(VehicleYear.Create(request.Year));
        entity.UpdateColor(VehicleColor.Create(request.Color));
        entity.UpdateActive(VehicleActive.Create(request.Active));

        await _uow.Vehicles.UpdateAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}