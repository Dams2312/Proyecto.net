using System;
using MediatR;
using Customer = Domain.Entities.Customers.Customer;

namespace Application.UseCase.Customers;

public sealed record DeleteCustomer(
    Guid Id
) : IRequest<Unit>;

