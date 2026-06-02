using System;
using MediatR;
using SparePartEntity = Domain.Entities.SparePart.SparePart;

namespace Application.UseCase.SparePart;

public sealed record UpdateSparePart(
    Guid Id,
    Guid CountryId,
    string Name,
    string Code
) : IRequest<Unit>;
