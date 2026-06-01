using System.Collections.Generic;
using Domain.Entities.OrderNote;
using MediatR;

namespace Application.UseCases.OrderNote;

public sealed record GetOrderNotesPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<OrderNote>>;
