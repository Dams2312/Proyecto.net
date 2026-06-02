using System;
using MediatR;
using PaymentEntity = Domain.Entities.Payment.Payment;

namespace Application.UseCase.Payment;

public sealed record UpdatePayment(
    Guid Id,
    Guid InvoiceId,
    Guid PaymentMethodId,
    DateTime FechaPago,
    decimal Monto,
    string Referencia,
    string Estado
) : IRequest<Unit>;

