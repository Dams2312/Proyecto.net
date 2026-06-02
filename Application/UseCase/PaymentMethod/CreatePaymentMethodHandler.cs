using Domain.ValueObject.PaymentMethod;
using Application.Abstractions;
using MediatR;
using PaymentMethodEntity = Domain.Entities.PaymentMethod.PaymentMethod;

namespace Application.UseCase.PaymentMethod;

public sealed class CreatePaymentMethodHandler
    : IRequestHandler<CreatePaymentMethod, Guid>
{
    private readonly IUnitOfWork _uow;

    public CreatePaymentMethodHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Guid> Handle(
        CreatePaymentMethod request,
        CancellationToken ct)
    {
        var name = PaymentMethodName.Create(request.Name);

        var description = PaymentMethodDescription.Create(request.Description);

        var paymentMethod = new PaymentMethodEntity(name, description);

        await _uow.PaymentMethods.AddAsync(paymentMethod, ct);

        await _uow.SaveChangesAsync(ct);

        return paymentMethod.Id;
    }
}
