using Domain.ValueObject.OrderStatus;
using Application.Abstractions;
using MediatR;
using OrderStatusEntity = Domain.Entities.OrderStatus.OrderStatus;

namespace Application.UseCase.OrderStatus;

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
