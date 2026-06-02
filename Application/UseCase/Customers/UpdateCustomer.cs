using System;
using MediatR;
using Customer = Domain.Entities.Customers.Customer;

namespace Application.UseCase.Customers;

public sealed record UpdateCustomer(
    Guid Id,
    string Names,
    string Surnames,
    string DocumentNumber,
    string DocumentType,
    bool Active
) : IRequest<Unit>;

