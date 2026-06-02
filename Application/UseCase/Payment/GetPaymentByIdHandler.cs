using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using PaymentEntity = Domain.Entities.Payment.Payment;

namespace Application.UseCase.Payment;

public sealed class GetPaymentByIdHandler
    : IRequestHandler<GetPaymentById, PaymentEntity>
{
    private readonly IUnitOfWork _uow;

    public GetPaymentByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<PaymentEntity> Handle(
        GetPaymentById request,
        CancellationToken ct)
    {
        var entity = await _uow.Payments.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("PaymentEntity no encontrado.");

        return entity;
    }
}
