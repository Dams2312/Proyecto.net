using System.Collections.Generic;
using MediatR;
using VehicleEntity = Domain.Entities.Vehicle.Vehicle;

namespace Application.UseCase.Vehicle;

public sealed record GetVehiclesPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<VehicleEntity>>;
