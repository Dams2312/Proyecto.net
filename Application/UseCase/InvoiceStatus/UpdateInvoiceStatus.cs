using System;
using MediatR;
using InvoiceStatusEntity = Domain.Entities.InvoiceStatus.InvoiceStatus;

namespace Application.UseCase.InvoiceStatus;

public sealed record UpdateInvoiceStatus(
    Guid Id,
    string Name
) : IRequest<Unit>;

