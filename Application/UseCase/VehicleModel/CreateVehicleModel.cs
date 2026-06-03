using System;
using MediatR;

namespace Application.UseCase.VehicleModel;

public sealed record CreateVehicleModel(
    Guid BrandId,
    string Name,
    int? YearFrom,
    int? YearTo
) : IRequest<Guid>;
