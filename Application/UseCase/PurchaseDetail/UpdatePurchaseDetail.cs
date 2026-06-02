using System;
using MediatR;
using PurchaseDetailEntity = Domain.Entities.PurchaseDetail.PurchaseDetail;

namespace Application.UseCase.PurchaseDetail;

public sealed record UpdatePurchaseDetail(
    Guid Id,
    Guid PurchaseId,
    Guid SparePartId,
    int Quantity,
    decimal UnitPrice
) : IRequest<Unit>;

