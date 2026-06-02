using System;
using MediatR;
using WarrantyEntity = Domain.Entities.Warranty.Warranty;

namespace Application.UseCase.Warranty;

public sealed record UpdateWarranty(
    Guid Id,
    Guid CountryId,
    string Name,
    string Code
) : IRequest<Unit>;
