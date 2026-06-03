using System;
using MediatR;

namespace Application.UseCase.VehicleMake;

public sealed record UpdateVehicleMake(
    Guid Id,
    string Name
) : IRequest<Unit>;
