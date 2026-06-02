using System.Collections.Generic;
using MediatR;
using InvoiceStatusEntity = Domain.Entities.InvoiceStatus.InvoiceStatus;

namespace Application.UseCase.InvoiceStatus;

public sealed record GetInvoiceStatusesPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<InvoiceStatusEntity>>;

