using System.Collections.Generic;
using MediatR;
using CustomerPhoneEntity = Domain.Entities.CustomerPhones.CustomerPhone;

namespace Application.UseCase.CustomerPhone;

public sealed record GetCustomerPhonesPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<CustomerPhoneEntity>>;
