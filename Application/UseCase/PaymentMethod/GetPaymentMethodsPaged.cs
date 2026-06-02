using System.Collections.Generic;
using MediatR;
using PaymentMethodEntity = Domain.Entities.PaymentMethod.PaymentMethod;

namespace Application.UseCase.PaymentMethod;

public sealed record GetPaymentMethodsPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<PaymentMethodEntity>>;

