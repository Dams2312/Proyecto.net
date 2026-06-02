using System.Collections.Generic;
using Domain.Entities.Customers;
using MediatR;
using Customer = Domain.Entities.Customers.Customer;

namespace Application.UseCase.Customers;

public sealed record GetCustomersPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<Customer>>;

