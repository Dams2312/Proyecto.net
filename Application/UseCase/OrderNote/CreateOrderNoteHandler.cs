using Domain.ValueObject.OrderNote;
using Application.Abstractions;
using MediatR;
using OrderNoteEntity = Domain.Entities.OrderNote.OrderNote;

namespace Application.UseCase.OrderNote;

public sealed class CreateOrderNoteHandler
    : IRequestHandler<CreateOrderNote, Guid>
{
    private readonly IUnitOfWork _uow;

    public CreateOrderNoteHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Guid> Handle(
        CreateOrderNote request,
        CancellationToken ct)
    {
        var orderId = OrderNoteOrderId.Create(request.OrderId);

        var userId = OrderNoteUserId.Create(request.UserId);

        var content = OrderNoteContent.Create(request.Content);

        var fechaNota = OrderNoteFechaNota.Create(request.FechaNota);

        var orderNote = new OrderNoteEntity(
            orderId,
            userId,
            fechaNota,
            content);

        await _uow.OrderNotes.AddAsync(orderNote, ct);

        await _uow.SaveChangesAsync(ct);

        return orderNote.Id;
    }
}
