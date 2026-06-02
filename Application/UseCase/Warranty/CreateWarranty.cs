using System;
using MediatR;
using WarrantyEntity = Domain.Entities.Warranty.Warranty;

namespace Application.UseCase.Warranty;

public sealed record CreateWarranty(
    string Name,
    Guid DepartmentId,
    string Code
) : IRequest<Guid>;
