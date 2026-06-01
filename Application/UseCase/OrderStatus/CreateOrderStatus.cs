using MediatR;

namespace Application.UseCases.OrderStatus;

public sealed record CreateOrderStatus(
    string Name,
    string Description
) : IRequest<Guid>;