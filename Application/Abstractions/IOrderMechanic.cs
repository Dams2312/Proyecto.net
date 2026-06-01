using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.OrderMechanic;

namespace Application.Abstractions;

public interface IOrderMechanic
{
    Task<OrderMechanic?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<OrderMechanic>> GetAllAsync(CancellationToken ct = default);
    Task<IReadOnlyList<OrderMechanic>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);

    Task AddAsync(OrderMechanic entity, CancellationToken ct = default);
    Task UpdateAsync(OrderMechanic entity, CancellationToken ct = default);
    Task RemoveAsync(OrderMechanic entity, CancellationToken ct = default);
}
