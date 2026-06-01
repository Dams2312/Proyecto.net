using System;
using MediatR;

namespace Application.UseCases.Customers;

public sealed record DeleteCustomer(
    Guid Id
) : IRequest<Unit>;
