using System;
using MediatR;

namespace Application.UseCases.MileageHistory;

public sealed record UpdateMileageHistory(
    Guid Id,
    Guid VehicleId,
    int Kilometraje,
    DateTime Date,
    string Source
) : IRequest<Unit>;
