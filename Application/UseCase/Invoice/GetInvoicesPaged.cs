using System.Collections.Generic;
using MediatR;
using InvoiceEntity = Domain.Entities.Invoice.Invoice;

namespace Application.UseCase.Invoice;

public sealed record GetInvoicesPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<InvoiceEntity>>;
