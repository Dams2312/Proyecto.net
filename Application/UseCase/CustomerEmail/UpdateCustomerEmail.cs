using System;
using MediatR;

namespace Application.UseCase.CustomerEmail;

public sealed record UpdateCustomerEmail(
    Guid Id,
    Guid CustomerId,
    string Address,
    bool Primary
) : IRequest<Unit>;
