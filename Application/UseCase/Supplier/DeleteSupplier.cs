using System;
using MediatR;
using SupplierEntity = Domain.Entities.Supplier.Supplier;

namespace Application.UseCase.Supplier;

public sealed record DeleteSupplier(Guid Id) : IRequest<Unit>;
