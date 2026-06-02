using System;
using Domain.Entities.Appointment;
using MediatR;
using AppointmentEntity = Domain.Entities.Appointment.Appointment;

namespace Application.UseCase.AppointmentEntity;

public sealed record GetAppoinmentById(
    Guid Id
) : IRequest<Appointment>;

