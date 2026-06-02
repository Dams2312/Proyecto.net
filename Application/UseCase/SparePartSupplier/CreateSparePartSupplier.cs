using System;
using MediatR;
using SparePartSupplierEntity = Domain.Entities.SparePartSupplier.SparePartSupplier;

namespace Application.UseCase.SparePartSupplier;

public sealed record CreateSparePartSupplier(
    string Name,
    Guid DepartmentId,
    string Code
) : IRequest<Guid>;
