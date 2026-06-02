using System;
using MediatR;
using PaymentMethodEntity = Domain.Entities.PaymentMethod.PaymentMethod;

namespace Application.UseCase.PaymentMethod;

public sealed record GetPaymentMethodById(
    Guid Id
) : IRequest<PaymentMethodEntity>;

