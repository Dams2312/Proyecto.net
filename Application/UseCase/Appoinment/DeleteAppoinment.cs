using System;
using MediatR;
using AppointmentEntity = Domain.Entities.Appointment.Appointment;

namespace Application.UseCase.AppointmentEntity;

public sealed record DeleteAppoinment(
    Guid Id
) : IRequest<Unit>;

