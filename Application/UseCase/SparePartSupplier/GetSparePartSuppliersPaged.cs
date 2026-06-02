using System.Collections.Generic;
using MediatR;
using SparePartSupplierEntity = Domain.Entities.SparePartSupplier.SparePartSupplier;

namespace Application.UseCase.SparePartSupplier;

public sealed record GetSparePartSuppliersPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<SparePartSupplierEntity>>;
