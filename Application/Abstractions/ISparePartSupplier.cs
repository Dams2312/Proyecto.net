using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.SparePartSupplier;

namespace Application.Abstractions;

public interface ISparePartSupplier
{
    Task<SparePartSupplier?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<SparePartSupplier>> GetAllAsync(CancellationToken ct = default);
    Task<IReadOnlyList<SparePartSupplier>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);

    Task AddAsync(SparePartSupplier entity, CancellationToken ct = default);
    Task UpdateAsync(SparePartSupplier entity, CancellationToken ct = default);
    Task RemoveAsync(SparePartSupplier entity, CancellationToken ct = default);
}
