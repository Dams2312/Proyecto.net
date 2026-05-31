using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.OrderServiceType;

namespace Application.Abstractions;

public interface IOrderServiceType
{
    Task<OrderServiceType?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<OrderServiceType>> GetAllAsync(CancellationToken ct = default);
    Task<IReadOnlyList<OrderServiceType>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);

    Task AddAsync(OrderServiceType entity, CancellationToken ct = default);
    Task UpdateAsync(OrderServiceType entity, CancellationToken ct = default);
    Task RemoveAsync(OrderServiceType entity, CancellationToken ct = default);
}
