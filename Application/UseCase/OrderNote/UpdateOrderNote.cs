using System;
using MediatR;
using OrderNoteEntity = Domain.Entities.OrderNote.OrderNote;

namespace Application.UseCase.OrderNote;

public sealed record UpdateOrderNote(
    Guid Id,
    Guid OrderId,
    Guid UserId,
    DateTime FechaNota,
    string Content
) : IRequest<Unit>;

