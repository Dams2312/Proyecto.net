using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using PurchaseEntity = Domain.Entities.Purchase.Purchase;

namespace Application.UseCase.Purchase;

public sealed class GetPurchaseByIdHandler
    : IRequestHandler<GetPurchaseById, PurchaseEntity>
{
    private readonly IUnitOfWork _uow;

    public GetPurchaseByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<PurchaseEntity> Handle(
        GetPurchaseById request,
        CancellationToken ct)
    {
        var entity = await _uow.Purchases.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("PurchaseEntity no encontrado.");

        return entity;
    }
}
