using Domain.ValueObject.OrderStatus;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using OrderStatusEntity = Domain.Entities.OrderStatus.OrderStatus;

namespace Application.UseCase.OrderStatus;

public sealed class UpdateOrderStatusHandler
    : IRequestHandler<UpdateOrderStatus, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateOrderStatusHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        UpdateOrderStatus request,
        CancellationToken ct)
    {
        var entity = await _uow.OrderStatuses.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("OrderStatusEntity no encontrado.");

        entity.UpdateName(OrderStatusName.Create(request.Name));
        entity.UpdateDescription(OrderStatusDescription.Create(request.Description));

        await _uow.OrderStatuses.UpdateAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}

