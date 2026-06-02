using System;
using MediatR;
using SparePartSupplierEntity = Domain.Entities.SparePartSupplier.SparePartSupplier;

namespace Application.UseCase.SparePartSupplier;

public sealed record GetSparePartSupplierById(Guid Id) : IRequest<SparePartSupplierEntity>;
