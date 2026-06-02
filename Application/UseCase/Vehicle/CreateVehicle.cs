using System;
using MediatR;
using VehicleEntity = Domain.Entities.Vehicle.Vehicle;

namespace Application.UseCase.Vehicle;

public sealed record CreateVehicle(
    string Name,
    Guid DepartmentId,
    string Code
) : IRequest<Guid>;
