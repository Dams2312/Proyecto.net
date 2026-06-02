using MediatR;
using InvoiceEntity = Domain.Entities.Invoice.Invoice;

namespace Application.UseCase.Invoice;

public sealed record CreateInvoice(
    Guid OrderId,
    Guid StatusId,
    Guid UserId,
    decimal CostoRepuestos,
    decimal ManoDeObra,
    decimal ImpuestoPct,
    decimal Descuento,
    decimal Total
) : IRequest<Guid>;
