using System;
using MediatR;
using PaymentMethodEntity = Domain.Entities.PaymentMethod.PaymentMethod;

namespace Application.UseCase.PaymentMethod;

public sealed record DeletePaymentMethod(
    Guid Id
) : IRequest<Unit>;

