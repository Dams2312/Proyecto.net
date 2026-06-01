using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.PurchaseDetail;
using MediatR;

namespace Application.UseCases.PurchaseDetail;

public sealed class GetPurchaseDetailByIdHandler
    : IRequestHandler<GetPurchaseDetailById, PurchaseDetail>
{
    private readonly IUnitOfWork _uow;

    public GetPurchaseDetailByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<PurchaseDetail> Handle(
        GetPurchaseDetailById request,
        CancellationToken ct)
    {
        var entity = await _uow.PurchaseDetails.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("PurchaseDetail no encontrado.");

        return entity;
    }
}
