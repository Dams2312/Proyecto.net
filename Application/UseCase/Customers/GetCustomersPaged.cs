using System.Collections.Generic;
using Domain.Entities.Customers;
using MediatR;

namespace Application.UseCases.Customers;

public sealed record GetCustomersPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<Customer>>;
