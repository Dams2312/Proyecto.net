using System.Collections.Generic;
using Domain.Entities.PaymentMethod;
using MediatR;

namespace Application.UseCases.PaymentMethod;

public sealed record GetPaymentMethodsPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<PaymentMethod>>;
