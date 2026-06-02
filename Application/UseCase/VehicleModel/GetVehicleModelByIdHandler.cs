using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using VehicleModelEntity = Domain.Entities.Vehiclemodel.VehicleModel;

namespace Application.UseCase.VehicleModel;

public sealed class GetVehicleModelByIdHandler : IRequestHandler<GetVehicleModelById, VehicleModelEntity>
{
    private readonly IUnitOfWork _uow;

    public GetVehicleModelByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<VehicleModelEntity> Handle(
        GetVehicleModelById request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
