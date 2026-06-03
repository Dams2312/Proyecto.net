using System;
using MediatR;

namespace Application.UseCase.Vehicle;

public sealed record UpdateVehicle(
    Guid Id,
    Guid ClientId,
    Guid ModelId,
    string Vin,
    string Plate,
    int Year,
    string Color,
    bool Active
) : IRequest<Unit>;
