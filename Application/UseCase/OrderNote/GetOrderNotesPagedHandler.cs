using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using OrderNoteEntity = Domain.Entities.OrderNote.OrderNote;

namespace Application.UseCase.OrderNote;

public sealed class GetOrderNotesPagedHandler
    : IRequestHandler<GetOrderNotesPaged, IReadOnlyList<OrderNoteEntity>>
{
    private readonly IUnitOfWork _uow;

    public GetOrderNotesPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<OrderNoteEntity>> Handle(
        GetOrderNotesPaged request,
        CancellationToken ct)
    {
        return await _uow.OrderNotes.GetPagedAsync(
            request.Page,
            request.PageSize,
            request.Search,
            ct);
    }
}

