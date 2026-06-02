using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using VehicleEntity = Domain.Entities.Vehicle.Vehicle;

namespace Application.UseCase.Vehicle;

public sealed class DeleteVehicleHandler : IRequestHandler<DeleteVehicle, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeleteVehicleHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        DeleteVehicle request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
