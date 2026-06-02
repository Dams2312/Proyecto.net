using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using VehicleMakeEntity = Domain.Entities.VehicleMake.VehicleMake;

namespace Application.UseCase.VehicleMake;

public sealed class DeleteVehicleMakeHandler : IRequestHandler<DeleteVehicleMake, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeleteVehicleMakeHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        DeleteVehicleMake request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
