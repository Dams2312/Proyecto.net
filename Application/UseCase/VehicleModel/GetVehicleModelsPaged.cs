using System.Collections.Generic;
using MediatR;
using VehicleModelEntity = Domain.Entities.Vehiclemodel.VehicleModel;

namespace Application.UseCase.VehicleModel;

public sealed record GetVehicleModelsPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<VehicleModelEntity>>;
