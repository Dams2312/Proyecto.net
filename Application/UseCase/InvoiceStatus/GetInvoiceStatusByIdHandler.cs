using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using InvoiceStatusEntity = Domain.Entities.InvoiceStatus.InvoiceStatus;

namespace Application.UseCase.InvoiceStatus;

public sealed class GetInvoiceStatusByIdHandler
    : IRequestHandler<GetInvoiceStatusById, InvoiceStatusEntity>
{
    private readonly IUnitOfWork _uow;

    public GetInvoiceStatusByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<InvoiceStatusEntity> Handle(
        GetInvoiceStatusById request,
        CancellationToken ct)
    {
        var entity = await _uow.InvoiceStatuses.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("InvoiceStatusEntity no encontrado.");

        return entity;
    }
}

