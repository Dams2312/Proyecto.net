using System;
using MediatR;

namespace Application.UseCase.Warranty;

public sealed record UpdateWarranty(
    Guid Id,
    DateTime StartDate,
    DateTime EndDate,
    string Status,
    string Conditions
) : IRequest<Unit>;
