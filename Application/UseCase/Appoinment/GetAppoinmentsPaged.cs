using System.Collections.Generic;
using Domain.Entities.Appointment;
using MediatR;
using AppointmentEntity = Domain.Entities.Appointment.Appointment;

namespace Application.UseCase.AppointmentEntity;

public sealed record GetAppoinmentsPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<Appointment>>;

