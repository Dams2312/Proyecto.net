using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.Payment;
using MediatR;

namespace Application.UseCases.Payment;

public sealed class GetPaymentByIdHandler
    : IRequestHandler<GetPaymentById, Payment>
{
    private readonly IUnitOfWork _uow;

    public GetPaymentByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Payment> Handle(
        GetPaymentById request,
        CancellationToken ct)
    {
        var entity = await _uow.Payments.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("Payment no encontrado.");

        return entity;
    }
}
