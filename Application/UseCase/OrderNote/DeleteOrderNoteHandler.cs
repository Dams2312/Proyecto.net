using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using OrderNoteEntity = Domain.Entities.OrderNote.OrderNote;

namespace Application.UseCase.OrderNote;

public sealed class DeleteOrderNoteHandler
    : IRequestHandler<DeleteOrderNote, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeleteOrderNoteHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        DeleteOrderNote request,
        CancellationToken ct)
    {
        var entity = await _uow.OrderNotes.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("OrderNoteEntity no encontrado.");

        await _uow.OrderNotes.RemoveAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}

