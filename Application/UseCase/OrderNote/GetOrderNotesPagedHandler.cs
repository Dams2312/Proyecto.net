using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.OrderNote;
using MediatR;

namespace Application.UseCases.OrderNote;

public sealed class GetOrderNotesPagedHandler
    : IRequestHandler<GetOrderNotesPaged, IReadOnlyList<OrderNote>>
{
    private readonly IUnitOfWork _uow;

    public GetOrderNotesPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<OrderNote>> Handle(
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
