using Domain.ValueObject.OrderStatusHistory;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using OrderStatusHistoryEntity = Domain.Entities.OrderStatusHistory.OrderStatusHistory;

namespace Application.UseCase.OrderStatusHistory;

public sealed class UpdateOrderStatusHistoryHandler
    : IRequestHandler<UpdateOrderStatusHistory, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateOrderStatusHistoryHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        UpdateOrderStatusHistory request,
        CancellationToken ct)
    {
        var entity = await _uow.OrderStatusHistories.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("OrderStatusHistoryEntity no encontrado.");

        entity.UpdateOrderId(OrderStatusHistoryOrderId.Create(request.OrderId));
        entity.UpdateStatusId(OrderStatusHistoryStatusId.Create(request.StatusId));
        entity.UpdateUserId(OrderStatusHistoryUserId.Create(request.UserId));
        entity.UpdateFechaCambio(OrderStatusHistoryFechaCambio.Create(request.FechaCambio));

        await _uow.OrderStatusHistories.UpdateAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}

