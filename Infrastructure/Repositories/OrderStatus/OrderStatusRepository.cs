using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using OrderStatuses = Domain.Entities.OrderStatus.OrderStatus;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.OrderStatus;

public sealed class OrderStatusRepository : IOrderStatus
{
    private readonly AppDbContext _context;

    public OrderStatusRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<OrderStatuses?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return _context.Set<OrderStatuses>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public Task<IReadOnlyList<OrderStatuses>> GetAllAsync(CancellationToken ct = default)
    {
        return _context.Set<OrderStatuses>()
            .AsNoTracking()
            .ToListAsync(ct)
            .ContinueWith(t => (IReadOnlyList<OrderStatuses>)t.Result, ct);
    }

    public async Task<IReadOnlyList<OrderStatuses>> GetPagedAsync(
        int page,
        int pageSize,
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<OrderStatuses> query = _context.Set<OrderStatuses>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Name.Value.Contains(normalized) ||
                x.Description != null && x.Description.Value != null && x.Description.Value.Contains(normalized));
        }

        return await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }

    public Task<int> CountAsync(
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<OrderStatuses> query = _context.Set<OrderStatuses>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Name.Value.Contains(normalized) ||
                x.Description != null && x.Description.Value != null && x.Description.Value.Contains(normalized));
        }

        return query.CountAsync(ct);
    }

    public Task AddAsync(OrderStatuses entity, CancellationToken ct = default)
    {
        _context.Set<OrderStatuses>().Add(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(OrderStatuses entity, CancellationToken ct = default)
    {
        _context.Set<OrderStatuses>().Update(entity);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(OrderStatuses entity, CancellationToken ct = default)
    {
        _context.Set<OrderStatuses>().Remove(entity);
        return Task.CompletedTask;
    }
}
