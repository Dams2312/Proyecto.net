using MediatR;

namespace Application.UseCases.Payment;

public sealed record CreatePayment(
    Guid InvoiceId,
    Guid PaymentMethodId,
    DateTime FechaPago,
    decimal Monto,
    string Referencia,
    string Estado
) : IRequest<Guid>;