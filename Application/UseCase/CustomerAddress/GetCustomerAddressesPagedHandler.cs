using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using CustomerAddressEntity = Domain.Entities.CustomerAddresses.CustomerAddress;

namespace Application.UseCase.CustomerAddress;

public sealed class GetCustomerAddressesPagedHandler
    : IRequestHandler<GetCustomerAddressesPaged, IReadOnlyList<CustomerAddressEntity>>
{
    private readonly IUnitOfWork _uow;

    public GetCustomerAddressesPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<CustomerAddressEntity>> Handle(
        GetCustomerAddressesPaged request,
        CancellationToken ct)
    {
        return await _uow.CustomerAddresses.GetPagedAsync(
            request.Page,
            request.PageSize,
            request.Search,
            ct);
    }
}
