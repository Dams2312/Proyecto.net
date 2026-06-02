using System;
using MediatR;

namespace Application.UseCase.CustomerAddress;

public sealed record CreateCustomerAddress(
    Guid CustomerId,
    Guid CityId,
    string Street,
    bool Primary
) : IRequest<Guid>;
