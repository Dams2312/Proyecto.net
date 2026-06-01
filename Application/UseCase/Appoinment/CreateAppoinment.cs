using System;
using MediatR;

namespace Application.UseCases.Appoinment;

public sealed record CreateAppoinment(
    Guid VehicleId,
    Guid ServiceTypeId,
    Guid ReceptionistId,
    DateOnly Date,
    TimeOnly StartTime,
    TimeOnly EndTime,
    string Status,
    string? Observations
) : IRequest<Guid>;
