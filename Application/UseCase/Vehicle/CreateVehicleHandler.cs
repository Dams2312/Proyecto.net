using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.ValueObject.Vehicle;
using MediatR;
using VehicleEntity = Domain.Entities.Vehicle.Vehicle;

namespace Application.UseCase.Vehicle;

public sealed class CreateVehicleHandler : IRequestHandler<CreateVehicle, Guid>
{
    private readonly IUnitOfWork _uow;
    public CreateVehicleHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<Guid> Handle(CreateVehicle request, CancellationToken ct)
    {
        var vin    = VehicleVin.Create(request.Vin);
        var plate  = VehiclePlate.Create(request.Plate);
        var year   = VehicleYear.Create(request.Year);
        var color  = VehicleColor.Create(request.Color);
        var active = VehicleActive.Create(request.Active);

        var entity = new VehicleEntity(request.ClientId, request.ModelId, vin, plate, year, color, active);
        await _uow.Vehicles.AddAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);
        return entity.Id;
    }
}