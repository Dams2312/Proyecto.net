using System;
using MediatR;
using VehicleModelEntity = Domain.Entities.Vehiclemodel.VehicleModel;

namespace Application.UseCase.VehicleModel;

public sealed record UpdateVehicleModel(
    Guid Id,
    Guid CountryId,
    string Name,
    string Code
) : IRequest<Unit>;
