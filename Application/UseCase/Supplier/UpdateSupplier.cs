using System;
using MediatR;
using SupplierEntity = Domain.Entities.Supplier.Supplier;

namespace Application.UseCase.Supplier;

public sealed record UpdateSupplier(
    Guid Id,
    Guid CountryId,
    string Name,
    string Code
) : IRequest<Unit>;
