using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;

namespace Application.UseCases.Payment;

public sealed class DeletePaymentHandler
    : IRequestHandler<DeletePayment, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeletePaymentHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        DeletePayment request,
        CancellationToken ct)
    {
        var entity = await _uow.Payments.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("Payment no encontrado.");

        await _uow.Payments.RemoveAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}
