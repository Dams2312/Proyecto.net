using System;
using MediatR;

namespace Application.UseCases.Payment;

public sealed record UpdatePayment(
    Guid Id,
    Guid InvoiceId,
    Guid PaymentMethodId,
    DateTime FechaPago,
    decimal Monto,
    string Referencia,
    string Estado
) : IRequest<Unit>;
