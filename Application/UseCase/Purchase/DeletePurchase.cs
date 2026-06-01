using System;
using MediatR;

namespace Application.UseCases.Purchase;

public sealed record DeletePurchase(
    Guid Id
) : IRequest<Unit>;
