using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using PurchaseEntity = Domain.Entities.Purchase.Purchase;

namespace Application.UseCase.Purchase;

public sealed class DeletePurchaseHandler
    : IRequestHandler<DeletePurchase, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeletePurchaseHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        DeletePurchase request,
        CancellationToken ct)
    {
        var entity = await _uow.Purchases.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("PurchaseEntity no encontrado.");

        await _uow.Purchases.RemoveAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}

