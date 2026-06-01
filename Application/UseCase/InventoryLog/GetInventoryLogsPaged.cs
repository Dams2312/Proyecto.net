using System.Collections.Generic;
using Domain.Entities.InventoryLog;
using MediatR;

namespace Application.UseCases.InventoryLog;

public sealed record GetInventoryLogsPaged(
    int Page,
    int PageSize,
    string? Search
) : IRequest<IReadOnlyList<InventoryLog>>;
