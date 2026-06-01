using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.PaymentMethod;
using MediatR;

namespace Application.UseCases.PaymentMethod;

public sealed class GetPaymentMethodByIdHandler
    : IRequestHandler<GetPaymentMethodById, PaymentMethod>
{
    private readonly IUnitOfWork _uow;

    public GetPaymentMethodByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<PaymentMethod> Handle(
        GetPaymentMethodById request,
        CancellationToken ct)
    {
        var entity = await _uow.PaymentMethods.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("PaymentMethod no encontrado.");

        return entity;
    }
}
