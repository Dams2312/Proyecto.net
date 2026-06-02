using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using OrderStatusHistoryEntity = Domain.Entities.OrderStatusHistory.OrderStatusHistory;

namespace Application.UseCase.OrderStatusHistory;

public sealed class GetOrderStatusHistoryByIdHandler
    : IRequestHandler<GetOrderStatusHistoryById, OrderStatusHistoryEntity>
{
    private readonly IUnitOfWork _uow;

    public GetOrderStatusHistoryByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<OrderStatusHistoryEntity> Handle(
        GetOrderStatusHistoryById request,
        CancellationToken ct)
    {
        var entity = await _uow.OrderStatusHistories.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("OrderStatusHistoryEntity no encontrado.");

        return entity;
    }
}

