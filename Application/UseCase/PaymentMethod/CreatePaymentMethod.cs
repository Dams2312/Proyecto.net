using MediatR;
using PaymentMethodEntity = Domain.Entities.PaymentMethod.PaymentMethod;

namespace Application.UseCase.PaymentMethod;

public sealed record CreatePaymentMethod(
    string Name,
    string Description
) : IRequest<Guid>;
