using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.Invoice;
using MediatR;

namespace Application.UseCases.Invoice;

public sealed class GetInvoicesPagedHandler
    : IRequestHandler<GetInvoicesPaged, IReadOnlyList<Invoice>>
{
    private readonly IUnitOfWork _uow;

    public GetInvoicesPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<Invoice>> Handle(
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
