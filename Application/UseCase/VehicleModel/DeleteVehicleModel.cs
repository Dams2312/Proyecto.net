using System;
using MediatR;
using VehicleModelEntity = Domain.Entities.Vehiclemodel.VehicleModel;

namespace Application.UseCase.VehicleModel;

public sealed record DeleteVehicleModel(Guid Id) : IRequest<Unit>;
