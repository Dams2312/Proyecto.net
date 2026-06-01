using System.Collections.Generic;
using Domain.Entities.Invoice;
using MediatR;

namespace Application.UseCases.Invoice;

public sealed record GetInvoicesPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<Invoice>>;
