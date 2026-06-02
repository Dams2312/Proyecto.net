using System;
using MediatR;
using SupplierEntity = Domain.Entities.Supplier.Supplier;

namespace Application.UseCase.Supplier;

public sealed record CreateSupplier(
    string Name,
    Guid DepartmentId,
    string Code
) : IRequest<Guid>;
