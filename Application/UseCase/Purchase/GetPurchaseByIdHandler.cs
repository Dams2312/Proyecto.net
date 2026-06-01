using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.Purchase;
using MediatR;

namespace Application.UseCases.Purchase;

public sealed class GetPurchaseByIdHandler
    : IRequestHandler<GetPurchaseById, Purchase>
{
    private readonly IUnitOfWork _uow;

    public GetPurchaseByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Purchase> Handle(
        GetPurchaseById request,
        CancellationToken ct)
    {
        var entity = await _uow.Purchases.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("Purchase no encontrado.");

        return entity;
    }
}
