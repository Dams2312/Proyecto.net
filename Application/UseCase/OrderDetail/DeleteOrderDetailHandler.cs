using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using OrderDetailEntity = Domain.Entities.OrderDetail.OrderDetail;

namespace Application.UseCase.OrderDetail;

public sealed class DeleteOrderDetailHandler
    : IRequestHandler<DeleteOrderDetail, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeleteOrderDetailHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        DeleteOrderDetail request,
        CancellationToken ct)
    {
        var entity = await _uow.OrderDetails.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("OrderDetailEntity no encontrado.");

        await _uow.OrderDetails.RemoveAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}

