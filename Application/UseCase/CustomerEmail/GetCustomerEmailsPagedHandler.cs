using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using CustomerEmailEntity = Domain.Entities.CustomerEmails.CustomerEmail;

namespace Application.UseCase.CustomerEmail;

public sealed class GetCustomerEmailsPagedHandler
    : IRequestHandler<GetCustomerEmailsPaged, IReadOnlyList<CustomerEmailEntity>>
{
    private readonly IUnitOfWork _uow;

    public GetCustomerEmailsPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<CustomerEmailEntity>> Handle(
        GetCustomerEmailsPaged request,
        CancellationToken ct)
    {
        return await _uow.CustomerEmails.GetPagedAsync(
            request.Page,
            request.PageSize,
            request.Search,
            ct);
    }
}
