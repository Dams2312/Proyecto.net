using System;
using MediatR;

namespace Application.UseCases.PurchaseDetail;

public sealed record UpdatePurchaseDetail(
    Guid Id,
    Guid PurchaseId,
    Guid SparePartId,
    int Quantity,
    decimal UnitPrice
) : IRequest<Unit>;
