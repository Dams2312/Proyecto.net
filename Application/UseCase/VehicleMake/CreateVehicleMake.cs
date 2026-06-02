using System;
using MediatR;
using VehicleMakeEntity = Domain.Entities.VehicleMake.VehicleMake;

namespace Application.UseCase.VehicleMake;

public sealed record CreateVehicleMake(
    string Name,
    Guid DepartmentId,
    string Code
) : IRequest<Guid>;
