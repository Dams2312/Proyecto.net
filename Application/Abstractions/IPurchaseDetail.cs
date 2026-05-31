using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.PurchaseDetail;

namespace Application.Abstractions;

public interface IPurchaseDetail
{
    Task<PurchaseDetail?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<PurchaseDetail>> GetAllAsync(CancellationToken ct = default);
    Task<IReadOnlyList<PurchaseDetail>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);

    Task AddAsync(PurchaseDetail entity, CancellationToken ct = default);
    Task UpdateAsync(PurchaseDetail entity, CancellationToken ct = default);
    Task RemoveAsync(PurchaseDetail entity, CancellationToken ct = default);
}
