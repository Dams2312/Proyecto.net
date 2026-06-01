using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.OrderNote;
using Domain.ValueObject.OrderNote;
using MediatR;

namespace Application.UseCases.OrderNote;

public sealed class UpdateOrderNoteHandler
    : IRequestHandler<UpdateOrderNote, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateOrderNoteHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        UpdateOrderNote request,
        CancellationToken ct)
    {
        var entity = await _uow.OrderNotes.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("OrderNote no encontrado.");

        entity.UpdateOrderId(OrderNoteOrderId.Create(request.OrderId));
        entity.UpdateUserId(OrderNoteUserId.Create(request.UserId));
        entity.UpdateFechaNota(OrderNoteFechaNota.Create(request.FechaNota));
        entity.UpdateContent(OrderNoteContent.Create(request.Content));

        await _uow.OrderNotes.UpdateAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}
