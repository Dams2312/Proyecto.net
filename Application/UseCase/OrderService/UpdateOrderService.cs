using System;
using MediatR;

namespace Application.UseCases.OrderService;

public sealed record UpdateOrderService(
    Guid Id,
    Guid VehicleId,
    Guid ReceptionistId,
    Guid StatusId,
    int KilometrajeIngreso,
    DateOnly FechaIngreso,
    DateOnly? FechaEstimada,
    DateOnly? FechaEntregaReal,
    Guid? AppointmentId,
    string Observaciones
) : IRequest<Unit>;
