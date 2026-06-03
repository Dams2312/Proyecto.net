using System;
using MediatR;

namespace Application.UseCase.VehicleMake;

public sealed record CreateVehicleMake(
    string Name
) : IRequest<Guid>;
