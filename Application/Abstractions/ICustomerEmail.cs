using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.CustomerEmails;

namespace Application.Abstractions;

public interface ICustomerEmail
{
    Task<CustomerEmail?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<CustomerEmail>> GetAllAsync(CancellationToken ct = default);
    Task<IReadOnlyList<CustomerEmail>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);

    Task AddAsync(CustomerEmail entity, CancellationToken ct = default);
    Task UpdateAsync(CustomerEmail entity, CancellationToken ct = default);
    Task RemoveAsync(CustomerEmail entity, CancellationToken ct = default);
}
