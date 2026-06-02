using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using InvoiceStatusEntity = Domain.Entities.InvoiceStatus.InvoiceStatus;

namespace Application.UseCase.InvoiceStatus;

public sealed class GetInvoiceStatusesPagedHandler
    : IRequestHandler<GetInvoiceStatusesPaged, IReadOnlyList<InvoiceStatusEntity>>
{
    private readonly IUnitOfWork _uow;

    public GetInvoiceStatusesPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<InvoiceStatusEntity>> Handle(
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

