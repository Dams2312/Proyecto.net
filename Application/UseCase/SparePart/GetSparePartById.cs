using System;
using MediatR;
using SparePartEntity = Domain.Entities.SparePart.SparePart;

namespace Application.UseCase.SparePart;

public sealed record GetSparePartById(Guid Id) : IRequest<SparePartEntity>;
