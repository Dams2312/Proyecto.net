using System;
using MediatR;
using SparePartSupplierEntity = Domain.Entities.SparePartSupplier.SparePartSupplier;

namespace Application.UseCase.SparePartSupplier;

public sealed record UpdateSparePartSupplier(
    Guid Id,
    Guid CountryId,
    string Name,
    string Code
) : IRequest<Unit>;
