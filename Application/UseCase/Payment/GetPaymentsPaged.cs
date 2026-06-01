using System.Collections.Generic;
using Domain.Entities.Payment;
using MediatR;

namespace Application.UseCases.Payment;

public sealed record GetPaymentsPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<Payment>>;
