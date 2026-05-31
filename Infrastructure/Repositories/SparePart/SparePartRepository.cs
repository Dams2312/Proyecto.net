using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using SpareParts = Domain.Entities.SparePart.SparePart;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.SparePart;

public sealed class SparePartRepository : ISparePart
{
    private readonly AppDbContext _context;

    public SparePartRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<SpareParts?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return _context.Set<SpareParts>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public Task<IReadOnlyList<SpareParts>> GetAllAsync(CancellationToken ct = default)
    {
        return _context.Set<SpareParts>()
            .AsNoTracking()
            .ToListAsync(ct)
            .ContinueWith(t => (IReadOnlyList<SpareParts>)t.Result, ct);
    }

    public async Task<IReadOnlyList<SpareParts>> GetPagedAsync(
        int page,
        int pageSize,
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<SpareParts> query = _context.Set<SpareParts>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Code.Value.Contains(normalized) ||
                x.Description.Value.Contains(normalized));
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
        IQueryable<SpareParts> query = _context.Set<SpareParts>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Code.Value.Contains(normalized) ||
                x.Description.Value.Contains(normalized));
        }

        return query.CountAsync(ct);
    }

    public Task AddAsync(SpareParts entity, CancellationToken ct = default)
    {
        _context.Set<SpareParts>().Add(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(SpareParts entity, CancellationToken ct = default)
    {
        _context.Set<SpareParts>().Update(entity);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(SpareParts entity, CancellationToken ct = default)
    {
        _context.Set<SpareParts>().Remove(entity);
        return Task.CompletedTask;
    }
}
