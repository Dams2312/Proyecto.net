using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.OrderStatus;
using MediatR;

namespace Application.UseCases.OrderStatus;

public sealed class GetOrderStatusByIdHandler
    : IRequestHandler<GetOrderStatusById, OrderStatus>
{
    private readonly IUnitOfWork _uow;

    public GetOrderStatusByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<OrderStatus> Handle(
        GetOrderStatusById request,
        CancellationToken ct)
    {
        var entity = await _uow.OrderStatuses.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("OrderStatus no encontrado.");

        return entity;
    }
}
