using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.MileageHistory;

namespace Application.Abstractions;

public interface IMileageHistory
{
    Task<MileageHistory?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<MileageHistory>> GetAllAsync(CancellationToken ct = default);
    Task<IReadOnlyList<MileageHistory>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);

    Task AddAsync(MileageHistory entity, CancellationToken ct = default);
    Task UpdateAsync(MileageHistory entity, CancellationToken ct = default);
    Task RemoveAsync(MileageHistory entity, CancellationToken ct = default);
}
