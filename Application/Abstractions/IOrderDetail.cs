using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.OrderDetail;

namespace Application.Abstractions;

public interface IOrderDetail
{
    Task<OrderDetail?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<OrderDetail>> GetAllAsync(CancellationToken ct = default);
    Task<IReadOnlyList<OrderDetail>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);

    Task AddAsync(OrderDetail entity, CancellationToken ct = default);
    Task UpdateAsync(OrderDetail entity, CancellationToken ct = default);
    Task RemoveAsync(OrderDetail entity, CancellationToken ct = default);
}
