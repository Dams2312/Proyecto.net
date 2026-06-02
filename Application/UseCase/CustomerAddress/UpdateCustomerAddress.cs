using System;
using MediatR;

namespace Application.UseCase.CustomerAddress;

public sealed record UpdateCustomerAddress(
    Guid Id,
    Guid CustomerId,
    Guid CityId,
    string Street,
    bool Primary
) : IRequest<Unit>;
