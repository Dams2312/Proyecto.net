using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using InvoiceEntity = Domain.Entities.Invoice.Invoice;

namespace Application.UseCase.Invoice;

public sealed class GetInvoiceByIdHandler
    : IRequestHandler<GetInvoiceById, InvoiceEntity>
{
    private readonly IUnitOfWork _uow;

    public GetInvoiceByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<InvoiceEntity> Handle(
        GetInvoiceById request,
        CancellationToken ct)
    {
        var entity = await _uow.Invoices.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("InvoiceEntity no encontrado.");

        return entity;
    }
}
