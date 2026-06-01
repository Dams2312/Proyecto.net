using System;
using Domain.Entities.PaymentMethod;
using MediatR;

namespace Application.UseCases.PaymentMethod;

public sealed record GetPaymentMethodById(
    Guid Id
) : IRequest<PaymentMethod>;
