using System.Collections.Generic;
using MediatR;
using CustomerAddressEntity = Domain.Entities.CustomerAddresses.CustomerAddress;

namespace Application.UseCase.CustomerAddress;

public sealed record GetCustomerAddressesPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<CustomerAddressEntity>>;
