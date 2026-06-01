using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.Payment;
using Domain.ValueObject.Payment;
using MediatR;

namespace Application.UseCases.Payment;

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
            throw new KeyNotFoundException("Payment no encontrado.");

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
