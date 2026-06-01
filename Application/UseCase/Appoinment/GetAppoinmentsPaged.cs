using System.Collections.Generic;
using Domain.Entities.Appointment;
using MediatR;

namespace Application.UseCases.Appoinment;

public sealed record GetAppoinmentsPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<Appointment>>;
