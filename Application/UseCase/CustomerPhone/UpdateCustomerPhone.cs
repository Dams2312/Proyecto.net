using System;
using MediatR;

namespace Application.UseCase.CustomerPhone;

public sealed record UpdateCustomerPhone(
    Guid Id,
    string PhoneNumber,
    string PhoneType,
    Guid CustomerId
) : IRequest<Unit>;
