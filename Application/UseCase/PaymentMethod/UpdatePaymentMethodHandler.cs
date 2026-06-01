using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.PaymentMethod;
using Domain.ValueObject.PaymentMethod;
using MediatR;

namespace Application.UseCases.PaymentMethod;

public sealed class UpdatePaymentMethodHandler
    : IRequestHandler<UpdatePaymentMethod, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdatePaymentMethodHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        UpdatePaymentMethod request,
        CancellationToken ct)
    {
        var entity = await _uow.PaymentMethods.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("PaymentMethod no encontrado.");

        entity.UpdateName(PaymentMethodName.Create(request.Name));
        entity.UpdateDescription(PaymentMethodDescription.Create(request.Description));

        await _uow.PaymentMethods.UpdateAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}
