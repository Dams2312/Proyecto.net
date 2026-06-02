using MediatR;
using OrderServiceTypeEntity = Domain.Entities.OrderServiceType.OrderServiceType;

namespace Application.UseCase.OrderServiceType;

public sealed record CreateOrderServiceType(
    Guid OrderId,
    Guid ServiceTypeId
) : IRequest<Guid>;
