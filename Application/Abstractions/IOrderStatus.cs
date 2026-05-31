using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.OrderStatus;

namespace Application.Abstractions;

public interface IOrderStatus
{
    Task<OrderStatus?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<OrderStatus>> GetAllAsync(CancellationToken ct = default);
    Task<IReadOnlyList<OrderStatus>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);

    Task AddAsync(OrderStatus entity, CancellationToken ct = default);
    Task UpdateAsync(OrderStatus entity, CancellationToken ct = default);
    Task RemoveAsync(OrderStatus entity, CancellationToken ct = default);
}
