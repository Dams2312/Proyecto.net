using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using VehicleEntity = Domain.Entities.Vehicle.Vehicle;

namespace Application.UseCase.Vehicle;

public sealed class UpdateVehicleHandler : IRequestHandler<UpdateVehicle, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateVehicleHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        UpdateVehicle request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
