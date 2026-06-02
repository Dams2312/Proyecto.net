using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using PaymentMethodEntity = Domain.Entities.PaymentMethod.PaymentMethod;

namespace Application.UseCase.PaymentMethod;

public sealed class GetPaymentMethodByIdHandler
    : IRequestHandler<GetPaymentMethodById, PaymentMethodEntity>
{
    private readonly IUnitOfWork _uow;

    public GetPaymentMethodByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<PaymentMethodEntity> Handle(
        GetPaymentMethodById request,
        CancellationToken ct)
    {
        var entity = await _uow.PaymentMethods.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("PaymentMethodEntity no encontrado.");

        return entity;
    }
}

