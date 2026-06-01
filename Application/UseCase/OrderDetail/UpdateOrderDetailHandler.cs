using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.OrderDetail;
using Domain.ValueObject.OrderDetail;
using MediatR;

namespace Application.UseCases.OrderDetail;

public sealed class UpdateOrderDetailHandler
    : IRequestHandler<UpdateOrderDetail, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateOrderDetailHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        UpdateOrderDetail request,
        CancellationToken ct)
    {
        var entity = await _uow.OrderDetails.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("OrderDetail no encontrado.");

        entity.UpdateOrderId(OrderDetailOrderId.Create(request.OrderId));
        entity.UpdateSparePartId(OrderDetailSparePartId.Create(request.SparePartId));
        entity.UpdateQuantity(OrderDetailQuantity.Create(request.Quantity));
        entity.UpdateUnitPrice(OrderDetailPriceSnapshot.Create(request.UnitPrice));

        await _uow.OrderDetails.UpdateAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}
