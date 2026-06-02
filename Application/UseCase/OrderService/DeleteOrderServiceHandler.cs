using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using OrderServiceEntity = Domain.Entities.OrderService.OrderService;

namespace Application.UseCase.OrderService;

public sealed class DeleteOrderServiceHandler
    : IRequestHandler<DeleteOrderService, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeleteOrderServiceHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        DeleteOrderService request,
        CancellationToken ct)
    {
        var entity = await _uow.OrderServices.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("OrderServiceEntity no encontrado.");

        await _uow.OrderServices.RemoveAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}

