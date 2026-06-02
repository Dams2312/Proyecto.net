using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using CustomerPhoneEntity = Domain.Entities.CustomerPhones.CustomerPhone;

namespace Application.UseCase.CustomerPhone;

public sealed class GetCustomerPhonesPagedHandler
    : IRequestHandler<GetCustomerPhonesPaged, IReadOnlyList<CustomerPhoneEntity>>
{
    private readonly IUnitOfWork _uow;

    public GetCustomerPhonesPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<CustomerPhoneEntity>> Handle(
        GetCustomerPhonesPaged request,
        CancellationToken ct)
    {
        return await _uow.CustomerPhones.GetPagedAsync(
            request.Page,
            request.PageSize,
            request.Search,
            ct);
    }
}
