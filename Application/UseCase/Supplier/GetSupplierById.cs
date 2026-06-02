using System;
using MediatR;
using SupplierEntity = Domain.Entities.Supplier.Supplier;

namespace Application.UseCase.Supplier;

public sealed record GetSupplierById(Guid Id) : IRequest<SupplierEntity>;
