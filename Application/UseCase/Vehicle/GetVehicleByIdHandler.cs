using Application.Abstractions;
using MediatR;
using VehicleEntity = Domain.Entities.Vehicle.Vehicle;

namespace Application.UseCase.Vehicle;

public sealed class GetVehicleByIdHandler : IRequestHandler<GetVehicleById, VehicleEntity>
{
    private readonly IUnitOfWork _uow;

    public GetVehicleByIdHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<VehicleEntity> Handle(GetVehicleById request, CancellationToken ct)
    {
        return await _uow.Vehicles.GetByIdAsync(request.Id, ct)
            ?? throw new KeyNotFoundException($"Vehículo con id {request.Id} no encontrado.");
    }
}