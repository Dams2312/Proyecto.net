using System;
using MediatR;

namespace Application.UseCases.InvoiceStatus;

public sealed record DeleteInvoiceStatus(
    Guid Id
) : IRequest<Unit>;
