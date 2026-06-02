using System;
using MediatR;
using PurchaseEntity = Domain.Entities.Purchase.Purchase;

namespace Application.UseCase.Purchase;

public sealed record GetPurchaseById(
    Guid Id
) : IRequest<PurchaseEntity>;
