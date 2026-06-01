using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.Citys;

namespace Application.Abstractions;

public interface ICity
{
    Task<City?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<City>> GetAllAsync(CancellationToken ct = default);
    Task<IReadOnlyList<City>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);

    Task AddAsync(City entity, CancellationToken ct = default);
    Task UpdateAsync(City entity, CancellationToken ct = default);
    Task RemoveAsync(City entity, CancellationToken ct = default);
}
