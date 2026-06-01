using System;
using Domain.Entities.Customers;
using MediatR;

namespace Application.UseCases.Customers;

public sealed record GetCustomerById(
    Guid Id
) : IRequest<Customer>;
