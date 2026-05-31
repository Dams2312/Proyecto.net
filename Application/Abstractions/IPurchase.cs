using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.Purchase;

namespace Application.Abstractions;

public interface IPurchase
{
    Task<Purchase?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<Purchase>> GetAllAsync(CancellationToken ct = default);
    Task<IReadOnlyList<Purchase>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);

    Task AddAsync(Purchase entity, CancellationToken ct = default);
    Task UpdateAsync(Purchase entity, CancellationToken ct = default);
    Task RemoveAsync(Purchase entity, CancellationToken ct = default);
}
