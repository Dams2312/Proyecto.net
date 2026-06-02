using MediatR;
using OrderStatusEntity = Domain.Entities.OrderStatus.OrderStatus;

namespace Application.UseCase.OrderStatus;

public sealed record CreateOrderStatus(
    string Name,
    string Description
) : IRequest<Guid>;
