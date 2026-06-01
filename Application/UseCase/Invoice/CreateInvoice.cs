using MediatR;

namespace Application.UseCases.Invoice;

public sealed record CreateInvoice(
    int OrderId,
    int StatusId,
    int UserId,
    decimal CostoRepuestos,
    decimal ManoDeObra,
    decimal ImpuestoPct,
    decimal Descuento,
    decimal Total
) : IRequest<Guid>;