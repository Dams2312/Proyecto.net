using System;
using MediatR;

namespace Application.UseCase.CustomerEmail;

public sealed record DeleteCustomerEmail(
    Guid Id
) : IRequest<Unit>;
