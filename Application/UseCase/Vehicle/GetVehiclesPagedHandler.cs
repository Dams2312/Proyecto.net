using Application.Abstractions;
using MediatR;
using VehicleEntity = Domain.Entities.Vehicle.Vehicle;

namespace Application.UseCase.Vehicle;

public sealed class GetVehiclesPagedHandler : IRequestHandler<GetVehiclesPaged, IReadOnlyList<VehicleEntity>>
{
    private readonly IUnitOfWork _uow;

    public GetVehiclesPagedHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<IReadOnlyList<VehicleEntity>> Handle(GetVehiclesPaged request, CancellationToken ct)
    {
        return await _uow.Vehicles.GetPagedAsync(request.Page, request.PageSize, request.Search, ct);
    }
}