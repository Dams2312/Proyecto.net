using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.InvoiceStatus;
using MediatR;

namespace Application.UseCases.InvoiceStatus;

public sealed class GetInvoiceStatusesPagedHandler
    : IRequestHandler<GetInvoiceStatusesPaged, IReadOnlyList<InvoiceStatus>>
{
    private readonly IUnitOfWork _uow;

    public GetInvoiceStatusesPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<InvoiceStatus>> Handle(
        GetInvoiceStatusesPaged request,
        CancellationToken ct)
    {
        return await _uow.InvoiceStatuses.GetPagedAsync(
            request.Page,
            request.PageSize,
            request.Search,
            ct);
    }
}
