using System;
using MediatR;
using SparePartEntity = Domain.Entities.SparePart.SparePart;

namespace Application.UseCase.SparePart;

public sealed record CreateSparePart(
    string Name,
    Guid DepartmentId,
    string Code
) : IRequest<Guid>;
