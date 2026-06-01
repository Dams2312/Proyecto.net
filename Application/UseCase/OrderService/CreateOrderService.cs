using MediatR;

namespace Application.UseCases.OrderService;

public sealed record CreateOrderService(
    int VehicleId,
    int ReceptionistId,
    int StatusId,
    int KilometrajeIngreso,
    DateOnly FechaIngreso,
    DateOnly? FechaEstimada,
    DateOnly? FechaEntregaReal,
    int? AppointmentId,
    string Observaciones
) : IRequest<Guid>;
