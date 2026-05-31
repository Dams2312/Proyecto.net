using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.Audit;

namespace Application.Abstractions;

public interface IAudit
{
    Task<Audit?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<Audit>> GetAllAsync(CancellationToken ct = default);
    Task<IReadOnlyList<Audit>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);

    Task AddAsync(Audit entity, CancellationToken ct = default);
    Task UpdateAsync(Audit entity, CancellationToken ct = default);
    Task RemoveAsync(Audit entity, CancellationToken ct = default);
}
