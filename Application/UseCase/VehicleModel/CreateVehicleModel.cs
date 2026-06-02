using System;
using MediatR;
using VehicleModelEntity = Domain.Entities.Vehiclemodel.VehicleModel;

namespace Application.UseCase.VehicleModel;

public sealed record CreateVehicleModel(
    string Name,
    Guid DepartmentId,
    string Code
) : IRequest<Guid>;
