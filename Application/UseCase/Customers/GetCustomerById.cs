using System;
using Domain.Entities.Customers;
using MediatR;
using Customer = Domain.Entities.Customers.Customer;

namespace Application.UseCase.Customers;

public sealed record GetCustomerById(
    Guid Id
) : IRequest<Customer>;

