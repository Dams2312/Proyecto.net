using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using PaymentEntity = Domain.Entities.Payment.Payment;

namespace Application.UseCase.Payment;

public sealed class GetPaymentsPagedHandler
    : IRequestHandler<GetPaymentsPaged, IReadOnlyList<PaymentEntity>>
{
    private readonly IUnitOfWork _uow;

    public GetPaymentsPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<PaymentEntity>> Handle(
        GetPaymentsPaged request,
        CancellationToken ct)
    {
        return await _uow.Payments.GetPagedAsync(
            request.Page,
            request.PageSize,
            request.Search,
            ct);
    }
}
