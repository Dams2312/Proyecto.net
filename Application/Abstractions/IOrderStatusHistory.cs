using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.OrderStatusHistory;

namespace Application.Abstractions;

public interface IOrderStatusHistory
{
    Task<OrderStatusHistory?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<OrderStatusHistory>> GetAllAsync(CancellationToken ct = default);
    Task<IReadOnlyList<OrderStatusHistory>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);

    Task AddAsync(OrderStatusHistory entity, CancellationToken ct = default);
    Task UpdateAsync(OrderStatusHistory entity, CancellationToken ct = default);
    Task RemoveAsync(OrderStatusHistory entity, CancellationToken ct = default);
}
