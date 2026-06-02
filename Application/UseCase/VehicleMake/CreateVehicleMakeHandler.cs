using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using VehicleMakeEntity = Domain.Entities.VehicleMake.VehicleMake;

namespace Application.UseCase.VehicleMake;

public sealed class CreateVehicleMakeHandler : IRequestHandler<CreateVehicleMake, Guid>
{
    private readonly IUnitOfWork _uow;

    public CreateVehicleMakeHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Guid> Handle(
        CreateVehicleMake request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
