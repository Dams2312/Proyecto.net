using System;
using MediatR;

namespace Application.UseCase.CustomerPhone;

public sealed record DeleteCustomerPhone(
    Guid Id
) : IRequest<Unit>;
