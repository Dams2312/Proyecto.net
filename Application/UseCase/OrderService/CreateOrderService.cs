using MediatR;

namespace Application.UseCases.OrderService;

public sealed record CreateOrderService(
    Guid VehicleId,
    Guid ReceptionistId,
    Guid StatusId,
    int KilometrajeIngreso,
    DateOnly FechaIngreso,
    DateOnly? FechaEstimada,
    DateOnly? FechaEntregaReal,
    Guid? AppointmentId,
    string Observaciones
) : IRequest<Guid>;
