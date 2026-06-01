using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.OrderNote;

namespace Application.Abstractions;

public interface IOrderNote
{
    Task<OrderNote?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<OrderNote>> GetAllAsync(CancellationToken ct = default);
    Task<IReadOnlyList<OrderNote>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);

    Task AddAsync(OrderNote entity, CancellationToken ct = default);
    Task UpdateAsync(OrderNote entity, CancellationToken ct = default);
    Task RemoveAsync(OrderNote entity, CancellationToken ct = default);
}
