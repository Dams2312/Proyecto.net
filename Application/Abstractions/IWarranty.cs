using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.Warranty;

namespace Application.Abstractions;

public interface IWarranty
{
    Task<Warranty?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<Warranty>> GetAllAsync(CancellationToken ct = default);
    Task<IReadOnlyList<Warranty>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);

    Task AddAsync(Warranty entity, CancellationToken ct = default);
    Task UpdateAsync(Warranty entity, CancellationToken ct = default);
    Task RemoveAsync(Warranty entity, CancellationToken ct = default);
}
