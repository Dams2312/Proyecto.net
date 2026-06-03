using System;
using MediatR;

namespace Application.UseCase.SparePartSupplier;

public sealed record CreateSparePartSupplier(
    Guid SparePartId,
    Guid SupplierId,
    decimal PurchasePrice,
    bool Principal
) : IRequest<Guid>;
