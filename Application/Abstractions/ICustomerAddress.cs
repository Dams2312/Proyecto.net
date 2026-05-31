using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.CustomerAddresses;

namespace Application.Abstractions;

public interface ICustomerAddress
{
    Task<CustomerAddress?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<CustomerAddress>> GetAllAsync(CancellationToken ct = default);
    Task<IReadOnlyList<CustomerAddress>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);

    Task AddAsync(CustomerAddress entity, CancellationToken ct = default);
    Task UpdateAsync(CustomerAddress entity, CancellationToken ct = default);
    Task RemoveAsync(CustomerAddress entity, CancellationToken ct = default);
}
