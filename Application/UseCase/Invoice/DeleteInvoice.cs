using System;
using MediatR;
using InvoiceEntity = Domain.Entities.Invoice.Invoice;

namespace Application.UseCase.Invoice;

public sealed record DeleteInvoice(
    Guid Id
) : IRequest<Unit>;

