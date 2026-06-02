using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using PaymentMethodEntity = Domain.Entities.PaymentMethod.PaymentMethod;

namespace Application.UseCase.PaymentMethod;

public sealed class DeletePaymentMethodHandler
    : IRequestHandler<DeletePaymentMethod, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeletePaymentMethodHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        DeletePaymentMethod request,
        CancellationToken ct)
    {
        var entity = await _uow.PaymentMethods.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("PaymentMethodEntity no encontrado.");

        await _uow.PaymentMethods.RemoveAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}

