using System.Collections.Generic;
using Domain.Entities.InvoiceStatus;
using MediatR;

namespace Application.UseCases.InvoiceStatus;

public sealed record GetInvoiceStatusesPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<InvoiceStatus>>;
