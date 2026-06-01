using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.PaymentMethod;
using MediatR;

namespace Application.UseCases.PaymentMethod;

public sealed class GetPaymentMethodsPagedHandler
    : IRequestHandler<GetPaymentMethodsPaged, IReadOnlyList<PaymentMethod>>
{
    private readonly IUnitOfWork _uow;

    public GetPaymentMethodsPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<PaymentMethod>> Handle(
        GetPaymentMethodsPaged request,
        CancellationToken ct)
    {
        return await _uow.PaymentMethods.GetPagedAsync(
            request.Page,
            request.PageSize,
            request.Search,
            ct);
    }
}
