using System;
using MediatR;

namespace Application.UseCase.Warranty;

public sealed record CreateWarranty(
    DateTime StartDate,
    DateTime EndDate,
    string Status,
    string Conditions
) : IRequest<Guid>;
