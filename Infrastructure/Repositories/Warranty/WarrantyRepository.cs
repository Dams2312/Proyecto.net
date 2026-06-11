using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Warranties = Domain.Entities.Warranty.Warranty;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Warranty;

public sealed class WarrantyRepository : IWarranty
{
    private readonly AppDbContext _context;

    public WarrantyRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<Warranties?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return _context.Set<Warranties>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public Task<IReadOnlyList<Warranties>> GetAllAsync(CancellationToken ct = default)
    {
        return _context.Set<Warranties>()
            .AsNoTracking()
            .ToListAsync(ct)
            .ContinueWith(t => (IReadOnlyList<Warranties>)t.Result, ct);
    }

    public async Task<IReadOnlyList<Warranties>> GetPagedAsync(
        int page,
        int pageSize,
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<Warranties> query = _context.Set<Warranties>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Estado.Value.Contains(normalized) ||
                x.Condiciones != null && x.Condiciones.Value != null && x.Condiciones.Value.Contains(normalized));
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
        IQueryable<Warranties> query = _context.Set<Warranties>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Estado.Value.Contains(normalized) ||
                x.Condiciones != null && x.Condiciones.Value != null && x.Condiciones.Value.Contains(normalized));
        }

        return query.CountAsync(ct);
    }

    public Task AddAsync(Warranties entity, CancellationToken ct = default)
    {
        _context.Set<Warranties>().Add(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Warranties entity, CancellationToken ct = default)
    {
        _context.Set<Warranties>().Update(entity);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(Warranties entity, CancellationToken ct = default)
    {
        _context.Set<Warranties>().Remove(entity);
        return Task.CompletedTask;
    }
}
