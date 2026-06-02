using System.Collections.Generic;
using MediatR;
using VehicleMakeEntity = Domain.Entities.VehicleMake.VehicleMake;

namespace Application.UseCase.VehicleMake;

public sealed record GetVehicleMakesPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<VehicleMakeEntity>>;
