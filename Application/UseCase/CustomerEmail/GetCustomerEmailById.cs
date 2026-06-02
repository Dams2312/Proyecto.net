using System;
using MediatR;
using CustomerEmailEntity = Domain.Entities.CustomerEmails.CustomerEmail;

namespace Application.UseCase.CustomerEmail;

public sealed record GetCustomerEmailById(
    Guid Id
) : IRequest<CustomerEmailEntity>;
