using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using OrderServices = Domain.Entities.OrderService.OrderService;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.OrderService;

public sealed class OrderServiceRepository : IOrderService
{
    private readonly AppDbContext _context;

    public OrderServiceRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<OrderServices?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return _context.Set<OrderServices>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public Task<IReadOnlyList<OrderServices>> GetAllAsync(CancellationToken ct = default)
    {
        return _context.Set<OrderServices>()
            .AsNoTracking()
            .ToListAsync(ct)
            .ContinueWith(t => (IReadOnlyList<OrderServices>)t.Result, ct);
    }

    public async Task<IReadOnlyList<OrderServices>> GetPagedAsync(
        int page,
        int pageSize,
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<OrderServices> query = _context.Set<OrderServices>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Observaciones.Value.Contains(normalized));
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
        IQueryable<OrderServices> query = _context.Set<OrderServices>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Observaciones.Value.Contains(normalized));
        }

        return query.CountAsync(ct);
    }

    public Task AddAsync(OrderServices entity, CancellationToken ct = default)
    {
        _context.Set<OrderServices>().Add(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(OrderServices entity, CancellationToken ct = default)
    {
        _context.Set<OrderServices>().Update(entity);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(OrderServices entity, CancellationToken ct = default)
    {
        _context.Set<OrderServices>().Remove(entity);
        return Task.CompletedTask;
    }
}
