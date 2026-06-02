using System.Collections.Generic;
using MediatR;
using PaymentEntity = Domain.Entities.Payment.Payment;

namespace Application.UseCase.Payment;

public sealed record GetPaymentsPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<PaymentEntity>>;
