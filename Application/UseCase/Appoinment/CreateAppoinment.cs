using System;
using MediatR;

namespace Application.UseCases.Appoinment;

public sealed record CreateAppoinment(
    int VehicleId,
    int ServiceTypeId,
    int ReceptionistId,
    DateOnly Date,
    TimeOnly StartTime,
    TimeOnly EndTime,
    string Status,
    string? Observations
) : IRequest<Guid>;
