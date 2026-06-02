using Domain.ValueObject.OrderDetail;
using Application.Abstractions;
using MediatR;
using OrderDetailEntity = Domain.Entities.OrderDetail.OrderDetail;

namespace Application.UseCase.OrderDetail;

public sealed class CreateOrderDetailHandler
    : IRequestHandler<CreateOrderDetail, Guid>
{
    private readonly IUnitOfWork _uow;

    public CreateOrderDetailHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Guid> Handle(
        CreateOrderDetail request,
        CancellationToken ct)
    {
        var orderId = OrderDetailOrderId.Create(request.OrderId);

        var sparePartId = OrderDetailSparePartId.Create(request.SparePartId);

        var quantity = OrderDetailQuantity.Create(request.Quantity);

        var priceSnapshot = OrderDetailPriceSnapshot.Create(request.PriceSnapshot);

        var orderDetail = new OrderDetailEntity(
            orderId,
            sparePartId,
            quantity,
            priceSnapshot);

        await _uow.OrderDetails.AddAsync(orderDetail, ct);

        await _uow.SaveChangesAsync(ct);

        return orderDetail.Id;
    }
}
