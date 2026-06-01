using System;
using MediatR;

namespace Application.UseCases.Invoice;

public sealed record DeleteInvoice(
    Guid Id
) : IRequest<Unit>;
