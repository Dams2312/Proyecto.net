using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using PurchaseDetailEntity = Domain.Entities.PurchaseDetail.PurchaseDetail;

namespace Application.UseCase.PurchaseDetail;

public sealed class DeletePurchaseDetailHandler
    : IRequestHandler<DeletePurchaseDetail, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeletePurchaseDetailHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        DeletePurchaseDetail request,
        CancellationToken ct)
    {
        var entity = await _uow.PurchaseDetails.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("PurchaseDetailEntity no encontrado.");

        await _uow.PurchaseDetails.RemoveAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}

