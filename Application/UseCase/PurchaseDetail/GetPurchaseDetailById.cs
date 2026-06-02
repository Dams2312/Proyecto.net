using System;
using MediatR;
using PurchaseDetailEntity = Domain.Entities.PurchaseDetail.PurchaseDetail;

namespace Application.UseCase.PurchaseDetail;

public sealed record GetPurchaseDetailById(
    Guid Id
) : IRequest<PurchaseDetailEntity>;

