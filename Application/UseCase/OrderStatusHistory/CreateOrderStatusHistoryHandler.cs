using Domain.ValueObject.OrderStatusHistory;
using Application.Abstractions;
using MediatR;
using OrderStatusHistoryEntity = Domain.Entities.OrderStatusHistory.OrderStatusHistory;

namespace Application.UseCase.OrderStatusHistory;

public sealed class CreateOrderStatusHistoryHandler
    : IRequestHandler<CreateOrderStatusHistory, Guid>
{
    private readonly IUnitOfWork _uow;

    public CreateOrderStatusHistoryHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Guid> Handle(
        CreateOrderStatusHistory request,
        CancellationToken ct)
    {
        var orderId = OrderStatusHistoryOrderId.Create(request.OrderId);

        var statusId = OrderStatusHistoryStatusId.Create(request.StatusId);

        var userId = OrderStatusHistoryUserId.Create(request.UserId);

        var fechaCambio = OrderStatusHistoryFechaCambio.Create(request.FechaCambio);

        var orderStatusHistory = new OrderStatusHistoryEntity(
            orderId,
            statusId,
            userId,
            fechaCambio);

        await _uow.OrderStatusHistories.AddAsync(orderStatusHistory, ct);

        await _uow.SaveChangesAsync(ct);

        return orderStatusHistory.Id;
    }
}
