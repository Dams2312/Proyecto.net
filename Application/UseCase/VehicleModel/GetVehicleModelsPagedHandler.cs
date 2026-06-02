using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using VehicleModelEntity = Domain.Entities.Vehiclemodel.VehicleModel;

namespace Application.UseCase.VehicleModel;

public sealed class GetVehicleModelsPagedHandler : IRequestHandler<GetVehicleModelsPaged, IReadOnlyList<VehicleModelEntity>>
{
    private readonly IUnitOfWork _uow;

    public GetVehicleModelsPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<VehicleModelEntity>> Handle(
        GetVehicleModelsPaged request,
        CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}
