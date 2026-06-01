using System;
using MediatR;

namespace Application.UseCases.Invoice;

public sealed record UpdateInvoice(
    Guid Id,
    Guid OrderId,
    Guid StatusId,
    Guid UserId,
    decimal CostoRepuestos,
    decimal ManoDeObra,
    decimal ImpuestoPct,
    decimal Descuento,
    decimal Total
) : IRequest<Unit>;
