using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.SparePart;

namespace Application.Abstractions;

public interface ISparePart
{
    Task<SparePart?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<SparePart>> GetAllAsync(CancellationToken ct = default);
    Task<IReadOnlyList<SparePart>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);

    Task AddAsync(SparePart entity, CancellationToken ct = default);
    Task UpdateAsync(SparePart entity, CancellationToken ct = default);
    Task RemoveAsync(SparePart entity, CancellationToken ct = default);
}
