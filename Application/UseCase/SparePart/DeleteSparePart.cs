using System;
using MediatR;
using SparePartEntity = Domain.Entities.SparePart.SparePart;

namespace Application.UseCase.SparePart;

public sealed record DeleteSparePart(Guid Id) : IRequest<Unit>;
