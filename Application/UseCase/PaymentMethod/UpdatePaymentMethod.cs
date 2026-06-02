using System;
using MediatR;
using PaymentMethodEntity = Domain.Entities.PaymentMethod.PaymentMethod;

namespace Application.UseCase.PaymentMethod;

public sealed record UpdatePaymentMethod(
    Guid Id,
    string Name,
    string Description
) : IRequest<Unit>;

