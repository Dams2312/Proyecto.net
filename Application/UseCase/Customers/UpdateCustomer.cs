using System;
using MediatR;

namespace Application.UseCases.Customers;

public sealed record UpdateCustomer(
    Guid Id,
    string Names,
    string Surnames,
    string DocumentNumber,
    string DocumentType,
    bool Active
) : IRequest<Unit>;
