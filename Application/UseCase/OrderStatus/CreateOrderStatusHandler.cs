using Application.Abstractions;
using Domain.Entities.OrderStatus;
using Domain.ValueObject.OrderStatus;
using MediatR;
using OrderStatusEntity = Domain.Entities.OrderStatus.OrderStatus;

namespace Application.UseCases.OrderStatus;

public sealed class CreateOrderStatusHandler
    : IRequestHandler<CreateOrderStatus, Guid>
{
    private readonly IUnitOfWork _uow;

    public CreateOrderStatusHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Guid> Handle(
        CreateOrderStatus request,
        CancellationToken ct)
    {
        var name = OrderStatusName.Create(request.Name);

        var description = OrderStatusDescription.Create(request.Description);

        var orderStatus = new OrderStatusEntity(name, description);

        await _uow.OrderStatuses.AddAsync(orderStatus, ct);

        await _uow.SaveChangesAsync(ct);

        return orderStatus.Id;
    }
}