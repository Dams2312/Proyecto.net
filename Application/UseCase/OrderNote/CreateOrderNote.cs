using MediatR;
using OrderNoteEntity = Domain.Entities.OrderNote.OrderNote;

namespace Application.UseCase.OrderNote;

public sealed record CreateOrderNote(
    Guid OrderId,
    Guid UserId,
    string Content,
    DateTime FechaNota
) : IRequest<Guid>;
