using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using PaymentMethodEntity = Domain.Entities.PaymentMethod.PaymentMethod;

namespace Application.UseCase.PaymentMethod;

public sealed class GetPaymentMethodsPagedHandler
    : IRequestHandler<GetPaymentMethodsPaged, IReadOnlyList<PaymentMethodEntity>>
{
    private readonly IUnitOfWork _uow;

    public GetPaymentMethodsPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<PaymentMethodEntity>> Handle(
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

