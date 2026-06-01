using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.Customers;
using MediatR;

namespace Application.UseCases.Customers;

public sealed class GetCustomersPagedHandler
    : IRequestHandler<GetCustomersPaged, IReadOnlyList<Customer>>
{
    private readonly IUnitOfWork _uow;

    public GetCustomersPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<Customer>> Handle(
        GetCustomersPaged request,
        CancellationToken ct)
    {
        return await _uow.Customers.GetPagedAsync(
            request.Page,
            request.PageSize,
            request.Search,
            ct);
    }
}
