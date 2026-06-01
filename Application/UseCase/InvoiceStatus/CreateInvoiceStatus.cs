using MediatR;

namespace Application.UseCases.InvoiceStatus;

public sealed record CreateInvoiceStatus(
    string Name
) : IRequest<Guid>;