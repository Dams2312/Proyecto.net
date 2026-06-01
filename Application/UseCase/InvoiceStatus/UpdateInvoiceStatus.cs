using System;
using MediatR;

namespace Application.UseCases.InvoiceStatus;

public sealed record UpdateInvoiceStatus(
    Guid Id,
    string Name
) : IRequest<Unit>;
