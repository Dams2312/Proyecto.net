using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.InventoryLog;

namespace Application.Abstractions;

public interface IInventoryLog
{
    Task<InventoryLog?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<InventoryLog>> GetAllAsync(CancellationToken ct = default);
    Task<IReadOnlyList<InventoryLog>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);

    Task AddAsync(InventoryLog entity, CancellationToken ct = default);
    Task UpdateAsync(InventoryLog entity, CancellationToken ct = default);
    Task RemoveAsync(InventoryLog entity, CancellationToken ct = default);
}
