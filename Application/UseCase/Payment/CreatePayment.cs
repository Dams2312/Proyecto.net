using MediatR;

namespace Application.UseCases.Payment;

public sealed record CreatePayment(
    int InvoiceId,
    int PaymentMethodId,
    DateTime FechaPago,
    decimal Monto,
    string Referencia,
    string Estado
) : IRequest<Guid>;