using System;
using MediatR;
using VehicleMakeEntity = Domain.Entities.VehicleMake.VehicleMake;

namespace Application.UseCase.VehicleMake;

public sealed record GetVehicleMakeById(Guid Id) : IRequest<VehicleMakeEntity>;
