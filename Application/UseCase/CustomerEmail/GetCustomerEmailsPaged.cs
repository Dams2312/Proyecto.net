using System.Collections.Generic;
using MediatR;
using CustomerEmailEntity = Domain.Entities.CustomerEmails.CustomerEmail;

namespace Application.UseCase.CustomerEmail;

public sealed record GetCustomerEmailsPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<CustomerEmailEntity>>;
