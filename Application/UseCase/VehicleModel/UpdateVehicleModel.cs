using System;
using MediatR;

namespace Application.UseCase.VehicleModel;

public sealed record UpdateVehicleModel(
    Guid Id,
    Guid BrandId,
    string Name,
    int? YearFrom,
    int? YearTo
) : IRequest<Unit>;
