using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using OrderStatusHistoryEntity = Domain.Entities.OrderStatusHistory.OrderStatusHistory;

namespace Application.UseCase.OrderStatusHistory;

public sealed class DeleteOrderStatusHistoryHandler
    : IRequestHandler<DeleteOrderStatusHistory, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeleteOrderStatusHistoryHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        DeleteOrderStatusHistory request,
        CancellationToken ct)
    {
        var entity = await _uow.OrderStatusHistories.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("OrderStatusHistoryEntity no encontrado.");

        await _uow.OrderStatusHistories.RemoveAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}

