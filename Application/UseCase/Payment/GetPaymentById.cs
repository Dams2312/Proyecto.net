using System;
using MediatR;
using PaymentEntity = Domain.Entities.Payment.Payment;

namespace Application.UseCase.Payment;

public sealed record GetPaymentById(
    Guid Id
) : IRequest<PaymentEntity>;
