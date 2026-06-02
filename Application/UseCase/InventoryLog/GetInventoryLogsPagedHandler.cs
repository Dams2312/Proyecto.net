using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using InventoryLogEntity = Domain.Entities.InventoryLog.InventoryLog;

namespace Application.UseCase.InventoryLog;

public sealed class GetInventoryLogsPagedHandler
    : IRequestHandler<GetInventoryLogsPaged, IReadOnlyList<InventoryLogEntity>>
{
    private readonly IUnitOfWork _uow;

    public GetInventoryLogsPagedHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<IReadOnlyList<InventoryLogEntity>> Handle(
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

