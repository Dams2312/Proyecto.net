using System;
using MediatR;
using AppointmentEntity = Domain.Entities.Appointment.Appointment;

namespace Application.UseCase.AppointmentEntity;

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

