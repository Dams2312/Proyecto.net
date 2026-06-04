using System;
using MediatR;

namespace Application.UseCase.Warranty;

public sealed record CreateWarranty(
    Guid OrderId,
    Guid ServiceTypeId,
    Guid MechanicId,
    DateTime StartDate,
    DateTime EndDate,
    string Status,
    string? Conditions
) : IRequest<Guid>;