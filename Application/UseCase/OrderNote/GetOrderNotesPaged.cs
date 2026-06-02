using System.Collections.Generic;
using MediatR;
using OrderNoteEntity = Domain.Entities.OrderNote.OrderNote;

namespace Application.UseCase.OrderNote;

public sealed record GetOrderNotesPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<OrderNoteEntity>>;

