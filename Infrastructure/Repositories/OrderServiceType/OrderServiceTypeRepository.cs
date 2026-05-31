using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using OrderServiceTypes = Domain.Entities.OrderServiceType.OrderServiceType;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.OrderServiceType;

public sealed class OrderServiceTypeRepository : IOrderServiceType
{
    private readonly AppDbContext _context;

    public OrderServiceTypeRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<OrderServiceTypes?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return _context.Set<OrderServiceTypes>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public Task<IReadOnlyList<OrderServiceTypes>> GetAllAsync(CancellationToken ct = default)
    {
        return _context.Set<OrderServiceTypes>()
            .AsNoTracking()
            .ToListAsync(ct)
            .ContinueWith(t => (IReadOnlyList<OrderServiceTypes>)t.Result, ct);
    }

    public async Task<IReadOnlyList<OrderServiceTypes>> GetPagedAsync(
        int page,
        int pageSize,
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<OrderServiceTypes> query = _context.Set<OrderServiceTypes>().AsNoTracking();

        return await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }

    public Task<int> CountAsync(
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<OrderServiceTypes> query = _context.Set<OrderServiceTypes>().AsNoTracking();
        return query.CountAsync(ct);
    }

    public Task AddAsync(OrderServiceTypes entity, CancellationToken ct = default)
    {
        _context.Set<OrderServiceTypes>().Add(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(OrderServiceTypes entity, CancellationToken ct = default)
    {
        _context.Set<OrderServiceTypes>().Update(entity);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(OrderServiceTypes entity, CancellationToken ct = default)
    {
        _context.Set<OrderServiceTypes>().Remove(entity);
        return Task.CompletedTask;
    }
}
