using System;
using MediatR;

namespace Application.UseCase.CustomerEmail;

public sealed record CreateCustomerEmail(
    Guid CustomerId,
    string Address,
    bool Primary
) : IRequest<Guid>;
