using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using InvoiceEntity = Domain.Entities.Invoice.Invoice;

namespace Application.UseCase.Invoice;

public sealed class GetInvoicesPagedHandler
    : IRequestHandler<GetInvoicesPaged, IReadOnlyList<InvoiceEntity>>
{
    private readonly IUnitOfWork _uow;

    public GetInvoicesPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<InvoiceEntity>> Handle(
        GetInvoicesPaged request,
        CancellationToken ct)
    {
        return await _uow.Invoices.GetPagedAsync(
            request.Page,
            request.PageSize,
            request.Search,
            ct);
    }
}
