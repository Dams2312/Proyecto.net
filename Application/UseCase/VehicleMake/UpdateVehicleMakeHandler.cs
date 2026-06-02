using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using VehicleMakeEntity = Domain.Entities.VehicleMake.VehicleMake;

namespace Application.UseCase.VehicleMake;

public sealed class UpdateVehicleMakeHandler : IRequestHandler<UpdateVehicleMake, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateVehicleMakeHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        UpdateVehicleMake request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
