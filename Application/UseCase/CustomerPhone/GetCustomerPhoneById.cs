using System;
using MediatR;
using CustomerPhoneEntity = Domain.Entities.CustomerPhones.CustomerPhone;

namespace Application.UseCase.CustomerPhone;

public sealed record GetCustomerPhoneById(
    Guid Id
) : IRequest<CustomerPhoneEntity>;
