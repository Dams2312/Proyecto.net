using System;
using MediatR;

namespace Application.UseCases.PaymentMethod;

public sealed record UpdatePaymentMethod(
    Guid Id,
    string Name,
    string Description
) : IRequest<Unit>;
