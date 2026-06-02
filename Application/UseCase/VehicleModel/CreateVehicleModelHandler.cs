using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using VehicleModelEntity = Domain.Entities.Vehiclemodel.VehicleModel;

namespace Application.UseCase.VehicleModel;

public sealed class CreateVehicleModelHandler : IRequestHandler<CreateVehicleModel, Guid>
{
    private readonly IUnitOfWork _uow;

    public CreateVehicleModelHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Guid> Handle(
        CreateVehicleModel request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
