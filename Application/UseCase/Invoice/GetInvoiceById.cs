using System;
using Domain.Entities.Invoice;
using MediatR;

namespace Application.UseCases.Invoice;

public sealed record GetInvoiceById(
    Guid Id
) : IRequest<Invoice>;
