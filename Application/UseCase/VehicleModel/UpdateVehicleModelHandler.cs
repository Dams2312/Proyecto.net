using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using VehicleModelEntity = Domain.Entities.Vehiclemodel.VehicleModel;

namespace Application.UseCase.VehicleModel;

public sealed class UpdateVehicleModelHandler : IRequestHandler<UpdateVehicleModel, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateVehicleModelHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        UpdateVehicleModel request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
