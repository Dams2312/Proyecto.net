using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using OrderDetailEntity = Domain.Entities.OrderDetail.OrderDetail;

namespace Application.UseCase.OrderDetail;

public sealed class GetOrderDetailByIdHandler
    : IRequestHandler<GetOrderDetailById, OrderDetailEntity>
{
    private readonly IUnitOfWork _uow;

    public GetOrderDetailByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<OrderDetailEntity> Handle(
        GetOrderDetailById request,
        CancellationToken ct)
    {
        var entity = await _uow.OrderDetails.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("OrderDetailEntity no encontrado.");

        return entity;
    }
}

