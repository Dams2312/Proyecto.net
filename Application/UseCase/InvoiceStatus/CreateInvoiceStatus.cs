using MediatR;
using InvoiceStatusEntity = Domain.Entities.InvoiceStatus.InvoiceStatus;

namespace Application.UseCase.InvoiceStatus;

public sealed record CreateInvoiceStatus(
    string Name
) : IRequest<Guid>;
