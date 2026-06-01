using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Purchases = Domain.Entities.Purchase.Purchase;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Purchase;

public sealed class PurchaseRepository : IPurchase
{
    private readonly AppDbContext _context;

    public PurchaseRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<Purchases?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return _context.Set<Purchases>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public Task<IReadOnlyList<Purchases>> GetAllAsync(CancellationToken ct = default)
    {
        return _context.Set<Purchases>()
            .AsNoTracking()
            .ToListAsync(ct)
            .ContinueWith(t => (IReadOnlyList<Purchases>)t.Result, ct);
    }

    public async Task<IReadOnlyList<Purchases>> GetPagedAsync(
        int page,
        int pageSize,
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<Purchases> query = _context.Set<Purchases>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Status.Value.Contains(normalized) ||
                x.Observations.Value.Contains(normalized));
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
        IQueryable<Purchases> query = _context.Set<Purchases>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Status.Value.Contains(normalized) ||
                x.Observations.Value.Contains(normalized));
        }

        return query.CountAsync(ct);
    }

    public Task AddAsync(Purchases entity, CancellationToken ct = default)
    {
        _context.Set<Purchases>().Add(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Purchases entity, CancellationToken ct = default)
    {
        _context.Set<Purchases>().Update(entity);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(Purchases entity, CancellationToken ct = default)
    {
        _context.Set<Purchases>().Remove(entity);
        return Task.CompletedTask;
    }
}
