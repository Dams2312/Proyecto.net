using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using OrderStatusHistories = Domain.Entities.OrderStatusHistory.OrderStatusHistory;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.OrderStatusHistory;

public sealed class OrderStatusHistoryRepository : IOrderStatusHistory
{
    private readonly AppDbContext _context;

    public OrderStatusHistoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<OrderStatusHistories?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return _context.Set<OrderStatusHistories>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public Task<IReadOnlyList<OrderStatusHistories>> GetAllAsync(CancellationToken ct = default)
    {
        return _context.Set<OrderStatusHistories>()
            .AsNoTracking()
            .ToListAsync(ct)
            .ContinueWith(t => (IReadOnlyList<OrderStatusHistories>)t.Result, ct);
    }

    public async Task<IReadOnlyList<OrderStatusHistories>> GetPagedAsync(
        int page,
        int pageSize,
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<OrderStatusHistories> query = _context.Set<OrderStatusHistories>().AsNoTracking();

        return await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }

    public Task<int> CountAsync(
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<OrderStatusHistories> query = _context.Set<OrderStatusHistories>().AsNoTracking();
        return query.CountAsync(ct);
    }

    public Task AddAsync(OrderStatusHistories entity, CancellationToken ct = default)
    {
        _context.Set<OrderStatusHistories>().Add(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(OrderStatusHistories entity, CancellationToken ct = default)
    {
        _context.Set<OrderStatusHistories>().Update(entity);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(OrderStatusHistories entity, CancellationToken ct = default)
    {
        _context.Set<OrderStatusHistories>().Remove(entity);
        return Task.CompletedTask;
    }
}
