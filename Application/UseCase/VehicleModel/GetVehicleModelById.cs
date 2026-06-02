using System;
using MediatR;
using VehicleModelEntity = Domain.Entities.Vehiclemodel.VehicleModel;

namespace Application.UseCase.VehicleModel;

public sealed record GetVehicleModelById(Guid Id) : IRequest<VehicleModelEntity>;
