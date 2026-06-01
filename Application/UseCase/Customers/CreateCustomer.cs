using System;
using MediatR;

namespace Application.UseCases.Customers;

public sealed record CreateCustomer(
    string Names,
    string Surnames,
    string DocumentNumber,
    string DocumentType,
    bool Active
) : IRequest<Guid>;
