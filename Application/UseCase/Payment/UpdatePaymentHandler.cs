using Domain.ValueObject.Payment;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using PaymentEntity = Domain.Entities.Payment.Payment;

namespace Application.UseCase.Payment;

public sealed class UpdatePaymentHandler
    : IRequestHandler<UpdatePayment, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdatePaymentHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        UpdatePayment request,
        CancellationToken ct)
    {
        var entity = await _uow.Payments.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("PaymentEntity no encontrado.");

        entity.UpdateInvoiceId(request.InvoiceId);
        entity.UpdatePaymentMethodId(request.PaymentMethodId);
        entity.UpdateFechaPago(PaymentFechaPago.Create(request.FechaPago));
        entity.UpdateMonto(PaymentMonto.Create(request.Monto));
        entity.UpdateReferencia(PaymentReferencia.Create(request.Referencia));
        entity.UpdateEstado(PaymentEstado.Create(request.Estado));

        await _uow.Payments.UpdateAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}

