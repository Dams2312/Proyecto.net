using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.CustomerPhones;

namespace Application.Abstractions;

public interface ICustomerPhone
{
    Task<CustomerPhone?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<CustomerPhone>> GetAllAsync(CancellationToken ct = default);
    Task<IReadOnlyList<CustomerPhone>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);

    Task AddAsync(CustomerPhone entity, CancellationToken ct = default);
    Task UpdateAsync(CustomerPhone entity, CancellationToken ct = default);
    Task RemoveAsync(CustomerPhone entity, CancellationToken ct = default);
}
