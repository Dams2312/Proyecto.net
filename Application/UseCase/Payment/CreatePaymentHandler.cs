using Application.Abstractions;
using Domain.Entities.Payment;
using Domain.ValueObject.Payment;
using MediatR;
using PaymentEntity = Domain.Entities.Payment.Payment;

namespace Application.UseCases.Payment;

public sealed class CreatePaymentHandler
    : IRequestHandler<CreatePayment, Guid>
{
    private readonly IUnitOfWork _uow;

    public CreatePaymentHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Guid> Handle(
        CreatePayment request,
        CancellationToken ct)
    {
        var invoiceId = request.InvoiceId;

        var paymentMethodId = request.PaymentMethodId;

        var fechaPago = PaymentFechaPago.Create(request.FechaPago);

        var monto = PaymentMonto.Create(request.Monto);

        var referencia = PaymentReferencia.Create(request.Referencia);

        var estado = PaymentEstado.Create(request.Estado);

        var payment = new PaymentEntity(
            invoiceId,
            paymentMethodId,
            fechaPago,
            monto,
            referencia,
            estado);

        await _uow.Payments.AddAsync(payment, ct);

        await _uow.SaveChangesAsync(ct);

        return payment.Id;
    }
}