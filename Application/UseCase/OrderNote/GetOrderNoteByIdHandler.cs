using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.OrderNote;
using MediatR;

namespace Application.UseCases.OrderNote;

public sealed class GetOrderNoteByIdHandler
    : IRequestHandler<GetOrderNoteById, OrderNote>
{
    private readonly IUnitOfWork _uow;

    public GetOrderNoteByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<OrderNote> Handle(
        GetOrderNoteById request,
        CancellationToken ct)
    {
        var entity = await _uow.OrderNotes.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("OrderNote no encontrado.");

        return entity;
    }
}
