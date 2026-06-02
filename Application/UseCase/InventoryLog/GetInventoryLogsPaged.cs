using System.Collections.Generic;
using MediatR;
using InventoryLogEntity = Domain.Entities.InventoryLog.InventoryLog;

namespace Application.UseCase.InventoryLog;

public sealed record GetInventoryLogsPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<InventoryLogEntity>>;

