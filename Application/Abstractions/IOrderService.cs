using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.OrderService;

namespace Application.Abstractions;

public interface IOrderService
{
    Task<OrderService?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<OrderService>> GetAllAsync(CancellationToken ct = default);
    Task<IReadOnlyList<OrderService>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);

    Task AddAsync(OrderService entity, CancellationToken ct = default);
    Task UpdateAsync(OrderService entity, CancellationToken ct = default);
    Task RemoveAsync(OrderService entity, CancellationToken ct = default);
}
