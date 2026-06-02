using System;
using MediatR;
using CustomerAddressEntity = Domain.Entities.CustomerAddresses.CustomerAddress;

namespace Application.UseCase.CustomerAddress;

public sealed record GetCustomerAddressById(
    Guid Id
) : IRequest<CustomerAddressEntity>;
