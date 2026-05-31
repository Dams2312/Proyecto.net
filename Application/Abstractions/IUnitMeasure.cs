using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.UnitMeasure;

namespace Application.Abstractions;

public interface IUnitMeasure
{
    Task<UnitMeasure?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<UnitMeasure>> GetAllAsync(CancellationToken ct = default);
    Task<IReadOnlyList<UnitMeasure>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);

    Task AddAsync(UnitMeasure entity, CancellationToken ct = default);
    Task UpdateAsync(UnitMeasure entity, CancellationToken ct = default);
    Task RemoveAsync(UnitMeasure entity, CancellationToken ct = default);
}
