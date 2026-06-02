using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using VehicleEntity = Domain.Entities.Vehicle.Vehicle;

namespace Application.UseCase.Vehicle;

public sealed class CreateVehicleHandler : IRequestHandler<CreateVehicle, Guid>
{
    private readonly IUnitOfWork _uow;

    public CreateVehicleHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Guid> Handle(
        CreateVehicle request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
