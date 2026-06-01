using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.OrderStatusHistory;
using MediatR;

namespace Application.UseCases.OrderStatusHistory;

public sealed class GetOrderStatusHistoryByIdHandler
    : IRequestHandler<GetOrderStatusHistoryById, OrderStatusHistory>
{
    private readonly IUnitOfWork _uow;

    public GetOrderStatusHistoryByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<OrderStatusHistory> Handle(
        GetOrderStatusHistoryById request,
        CancellationToken ct)
    {
        var entity = await _uow.OrderStatusHistories.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("OrderStatusHistory no encontrado.");

        return entity;
    }
}
