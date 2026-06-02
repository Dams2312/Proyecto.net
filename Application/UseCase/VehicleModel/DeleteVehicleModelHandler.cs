using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using VehicleModelEntity = Domain.Entities.Vehiclemodel.VehicleModel;

namespace Application.UseCase.VehicleModel;

public sealed class DeleteVehicleModelHandler : IRequestHandler<DeleteVehicleModel, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeleteVehicleModelHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        DeleteVehicleModel request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
