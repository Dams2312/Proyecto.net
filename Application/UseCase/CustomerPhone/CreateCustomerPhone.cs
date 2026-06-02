using System;
using MediatR;

namespace Application.UseCase.CustomerPhone;

public sealed record CreateCustomerPhone(
    string PhoneNumber,
    string PhoneType,
    Guid CustomerId
) : IRequest<Guid>;
