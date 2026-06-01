using System;
using Domain.Entities.Appointment;
using MediatR;

namespace Application.UseCases.Appoinment;

public sealed record GetAppoinmentById(
    Guid Id
) : IRequest<Appointment>;
