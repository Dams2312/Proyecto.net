using System;
using Domain.Entities.Purchase;
using MediatR;

namespace Application.UseCases.Purchase;

public sealed record GetPurchaseById(
    Guid Id
) : IRequest<Purchase>;
