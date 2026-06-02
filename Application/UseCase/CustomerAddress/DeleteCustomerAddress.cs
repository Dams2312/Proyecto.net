using System;
using MediatR;

namespace Application.UseCase.CustomerAddress;

public sealed record DeleteCustomerAddress(
    Guid Id
) : IRequest<Unit>;
