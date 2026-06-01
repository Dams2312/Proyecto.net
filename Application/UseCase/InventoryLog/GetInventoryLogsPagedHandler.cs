using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.InventoryLog;
using MediatR;

namespace Application.UseCases.InventoryLog;

public sealed class GetInventoryLogsPagedHandler
    : IRequestHandler<GetInventoryLogsPaged, IReadOnlyList<InventoryLog>>
{
    private readonly IUnitOfWork _uow;

    public GetInventoryLogsPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<InventoryLog>> Handle(
        GetInventoryLogsPaged request,
        CancellationToken ct)
    {
        return await _uow.InventoryLogs.GetPagedAsync(
            request.Page,
            request.PageSize,
            request.Search,
            ct);
    }
}
