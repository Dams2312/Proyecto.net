using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.Countries;

namespace Application.Abstractions;

public interface ICountry
{
    Task<Country?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<Country>> GetAllAsync(CancellationToken ct = default);
    Task<IReadOnlyList<Country>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);

    Task AddAsync(Country entity, CancellationToken ct = default);
    Task UpdateAsync(Country entity, CancellationToken ct = default);
    Task RemoveAsync(Country entity, CancellationToken ct = default);
}
