using System;
using MediatR;

namespace Application.UseCases.Payment;

public sealed record DeletePayment(
    Guid Id
) : IRequest<Unit>;
