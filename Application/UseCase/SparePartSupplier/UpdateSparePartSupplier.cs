using System;
using MediatR;

namespace Application.UseCase.SparePartSupplier;

public sealed record UpdateSparePartSupplier(
    Guid Id,
    Guid SparePartId,
    Guid SupplierId,
    decimal PurchasePrice,
    bool Principal
) : IRequest<Unit>;
