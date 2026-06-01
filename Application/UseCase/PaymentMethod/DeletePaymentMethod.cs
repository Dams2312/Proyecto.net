using System;
using MediatR;

namespace Application.UseCases.PaymentMethod;

public sealed record DeletePaymentMethod(
    Guid Id
) : IRequest<Unit>;
