using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using OrderStatusEntity = Domain.Entities.OrderStatus.OrderStatus;

namespace Application.UseCase.OrderStatus;

public sealed class GetOrderStatusByIdHandler
    : IRequestHandler<GetOrderStatusById, OrderStatusEntity>
{
    private readonly IUnitOfWork _uow;

    public GetOrderStatusByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<OrderStatusEntity> Handle(
        GetOrderStatusById request,
        CancellationToken ct)
    {
        var entity = await _uow.OrderStatuses.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("OrderStatusEntity no encontrado.");

        return entity;
    }
}

