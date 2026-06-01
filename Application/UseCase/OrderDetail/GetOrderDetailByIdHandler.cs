using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.OrderDetail;
using MediatR;

namespace Application.UseCases.OrderDetail;

public sealed class GetOrderDetailByIdHandler
    : IRequestHandler<GetOrderDetailById, OrderDetail>
{
    private readonly IUnitOfWork _uow;

    public GetOrderDetailByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<OrderDetail> Handle(
        GetOrderDetailById request,
        CancellationToken ct)
    {
        var entity = await _uow.OrderDetails.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("OrderDetail no encontrado.");

        return entity;
    }
}
