using System;
using MediatR;
using OrderNoteEntity = Domain.Entities.OrderNote.OrderNote;

namespace Application.UseCase.OrderNote;

public sealed record DeleteOrderNote(
    Guid Id
) : IRequest<Unit>;

