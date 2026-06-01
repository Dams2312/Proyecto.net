using MediatR;

namespace Application.UseCases.OrderServiceType;

public sealed record CreateOrderServiceType(
    Guid OrderId,
    Guid ServiceTypeId
) : IRequest<Guid>;