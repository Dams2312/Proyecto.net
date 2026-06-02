using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using PurchaseDetailEntity = Domain.Entities.PurchaseDetail.PurchaseDetail;

namespace Application.UseCase.PurchaseDetail;

public sealed class GetPurchaseDetailByIdHandler
    : IRequestHandler<GetPurchaseDetailById, PurchaseDetailEntity>
{
    private readonly IUnitOfWork _uow;

    public GetPurchaseDetailByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<PurchaseDetailEntity> Handle(
        GetPurchaseDetailById request,
        CancellationToken ct)
    {
        var entity = await _uow.PurchaseDetails.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("PurchaseDetailEntity no encontrado.");

        return entity;
    }
}

