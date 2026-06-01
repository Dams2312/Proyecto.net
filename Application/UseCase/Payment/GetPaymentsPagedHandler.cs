using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.Payment;
using MediatR;

namespace Application.UseCases.Payment;

public sealed class GetPaymentsPagedHandler
    : IRequestHandler<GetPaymentsPaged, IReadOnlyList<Payment>>
{
    private readonly IUnitOfWork _uow;

    public GetPaymentsPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<Payment>> Handle(
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
