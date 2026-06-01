using MediatR;

namespace Application.UseCases.PaymentMethod;

public sealed record CreatePaymentMethod(
    string Name,
    string Description
) : IRequest<Guid>;