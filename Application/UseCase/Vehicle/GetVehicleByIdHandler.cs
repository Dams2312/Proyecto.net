using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using VehicleEntity = Domain.Entities.Vehicle.Vehicle;

namespace Application.UseCase.Vehicle;

public sealed class GetVehicleByIdHandler : IRequestHandler<GetVehicleById, VehicleEntity>
{
    private readonly IUnitOfWork _uow;

    public GetVehicleByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<VehicleEntity> Handle(
        GetVehicleById request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
