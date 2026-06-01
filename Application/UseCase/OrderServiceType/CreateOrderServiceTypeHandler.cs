using Application.Abstractions;
using Domain.Entities.OrderServiceType;
using Domain.ValueObject.OrderServiceType;
using MediatR;
using OrderServiceTypeEntity = Domain.Entities.OrderServiceType.OrderServiceType;

namespace Application.UseCases.OrderServiceType;

public sealed class CreateOrderServiceTypeHandler
    : IRequestHandler<CreateOrderServiceType, Guid>
{
    private readonly IUnitOfWork _uow;

    public CreateOrderServiceTypeHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Guid> Handle(
        CreateOrderServiceType request,
        CancellationToken ct)
    {
        var orderId = OrderServiceTypeOrderId.Create(request.OrderId);

        var serviceTypeId = OrderServiceTypeServiceTypeId.Create(request.ServiceTypeId);

        var orderServiceType = new OrderServiceTypeEntity(
            orderId,
            serviceTypeId);

        await _uow.OrderServiceTypes.AddAsync(orderServiceType, ct);

        await _uow.SaveChangesAsync(ct);

        return orderServiceType.Id;
    }
}