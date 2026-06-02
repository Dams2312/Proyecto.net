using System.Collections.Generic;
using MediatR;
using SupplierEntity = Domain.Entities.Supplier.Supplier;

namespace Application.UseCase.Supplier;

public sealed record GetSuppliersPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<SupplierEntity>>;
