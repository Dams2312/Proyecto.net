using System;
using MediatR;
using VehicleEntity = Domain.Entities.Vehicle.Vehicle;

namespace Application.UseCase.Vehicle;

public sealed record UpdateVehicle(
    Guid Id,
    Guid CountryId,
    string Name,
    string Code
) : IRequest<Unit>;
