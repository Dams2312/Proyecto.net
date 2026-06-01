using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.Invoice;
using MediatR;

namespace Application.UseCases.Invoice;

public sealed class GetInvoiceByIdHandler
    : IRequestHandler<GetInvoiceById, Invoice>
{
    private readonly IUnitOfWork _uow;

    public GetInvoiceByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Invoice> Handle(
        GetInvoiceById request,
        CancellationToken ct)
    {
        var entity = await _uow.Invoices.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("Invoice no encontrado.");

        return entity;
    }
}
