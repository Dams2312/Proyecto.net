using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.SpareCategory;

namespace Application.Abstractions;

public interface ISpareCategory
{
    Task<SpareCategory?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<SpareCategory>> GetAllAsync(CancellationToken ct = default);
    Task<IReadOnlyList<SpareCategory>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);

    Task AddAsync(SpareCategory entity, CancellationToken ct = default);
    Task UpdateAsync(SpareCategory entity, CancellationToken ct = default);
    Task RemoveAsync(SpareCategory entity, CancellationToken ct = default);
}
