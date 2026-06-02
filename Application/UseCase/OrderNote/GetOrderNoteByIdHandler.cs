using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using OrderNoteEntity = Domain.Entities.OrderNote.OrderNote;

namespace Application.UseCase.OrderNote;

public sealed class GetOrderNoteByIdHandler
    : IRequestHandler<GetOrderNoteById, OrderNoteEntity>
{
    private readonly IUnitOfWork _uow;

    public GetOrderNoteByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<OrderNoteEntity> Handle(
        GetOrderNoteById request,
        CancellationToken ct)
    {
        var entity = await _uow.OrderNotes.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("OrderNoteEntity no encontrado.");

        return entity;
    }
}

