using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.Supplier;

namespace Application.Abstractions;

public interface ISupplier
{
    Task<Supplier?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<Supplier>> GetAllAsync(CancellationToken ct = default);
    Task<IReadOnlyList<Supplier>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);

    Task AddAsync(Supplier entity, CancellationToken ct = default);
    Task UpdateAsync(Supplier entity, CancellationToken ct = default);
    Task RemoveAsync(Supplier entity, CancellationToken ct = default);
}
