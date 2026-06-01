using MediatR;

namespace Application.UseCases.OrderServiceType;

public sealed record CreateOrderServiceType(
    int OrderId,
    int ServiceTypeId
) : IRequest<Guid>;