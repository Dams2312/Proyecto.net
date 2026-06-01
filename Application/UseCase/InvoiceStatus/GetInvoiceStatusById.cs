using System;
using Domain.Entities.InvoiceStatus;
using MediatR;

namespace Application.UseCases.InvoiceStatus;

public sealed record GetInvoiceStatusById(
    Guid Id
) : IRequest<InvoiceStatus>;
