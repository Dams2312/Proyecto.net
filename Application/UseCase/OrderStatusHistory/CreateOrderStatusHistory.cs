using MediatR;

namespace Application.UseCases.OrderStatusHistory;

public sealed record CreateOrderStatusHistory(
    int OrderId,
    int StatusId,
    int UserId,
    DateTime FechaCambio
) : IRequest<Guid>;