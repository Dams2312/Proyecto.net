using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using OrderStatusEntity = Domain.Entities.OrderStatus.OrderStatus;

namespace Application.UseCase.OrderStatus;

public sealed class DeleteOrderStatusHandler
    : IRequestHandler<DeleteOrderStatus, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeleteOrderStatusHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        DeleteOrderStatus request,
        CancellationToken ct)
    {
        var entity = await _uow.OrderStatuses.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("OrderStatusEntity no encontrado.");

        await _uow.OrderStatuses.RemoveAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}

