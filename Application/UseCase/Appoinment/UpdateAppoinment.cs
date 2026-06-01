using System;
using MediatR;

namespace Application.UseCases.Appoinment;

public sealed record UpdateAppoinment(
    Guid Id,
    Guid VehicleId,
    Guid ServiceTypeId,
    Guid ReceptionistId,
    DateOnly Date,
    TimeOnly StartTime,
    TimeOnly EndTime,
    string Status,
    string? Observations
) : IRequest<Unit>;
