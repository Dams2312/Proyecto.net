using System;
using MediatR;
using VehicleEntity = Domain.Entities.Vehicle.Vehicle;

namespace Application.UseCase.Vehicle;

public sealed record DeleteVehicle(Guid Id) : IRequest<Unit>;
