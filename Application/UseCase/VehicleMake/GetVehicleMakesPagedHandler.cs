using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using VehicleMakeEntity = Domain.Entities.VehicleMake.VehicleMake;

namespace Application.UseCase.VehicleMake;

public sealed class GetVehicleMakesPagedHandler : IRequestHandler<GetVehicleMakesPaged, IReadOnlyList<VehicleMakeEntity>>
{
    private readonly IUnitOfWork _uow;
    public GetVehicleMakesPagedHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<IReadOnlyList<VehicleMakeEntity>> Handle(GetVehicleMakesPaged request, CancellationToken ct)
        => await _uow.VehicleMakes.GetPagedAsync(request.Page, request.PageSize, request.Search, ct);
}