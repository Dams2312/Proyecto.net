using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.MechanicTask;

namespace Application.Abstractions;

public interface IMechanicTask
{
    Task<MechanicTask?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<MechanicTask>> GetAllAsync(CancellationToken ct = default);
    Task<IReadOnlyList<MechanicTask>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);

    Task AddAsync(MechanicTask entity, CancellationToken ct = default);
    Task UpdateAsync(MechanicTask entity, CancellationToken ct = default);
    Task RemoveAsync(MechanicTask entity, CancellationToken ct = default);
}
