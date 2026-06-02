using System;
using MediatR;
using VehicleMakeEntity = Domain.Entities.VehicleMake.VehicleMake;

namespace Application.UseCase.VehicleMake;

public sealed record UpdateVehicleMake(
    Guid Id,
    Guid CountryId,
    string Name,
    string Code
) : IRequest<Unit>;
