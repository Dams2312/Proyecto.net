using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using SpareCategories = Domain.Entities.SpareCategory.SpareCategory;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.SpareCategory;

public sealed class SpareCategoryRepository : ISpareCategory
{
    private readonly AppDbContext _context;

    public SpareCategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<SpareCategories?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return _context.Set<SpareCategories>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public Task<IReadOnlyList<SpareCategories>> GetAllAsync(CancellationToken ct = default)
    {
        return _context.Set<SpareCategories>()
            .AsNoTracking()
            .ToListAsync(ct)
            .ContinueWith(t => (IReadOnlyList<SpareCategories>)t.Result, ct);
    }

    public async Task<IReadOnlyList<SpareCategories>> GetPagedAsync(
        int page,
        int pageSize,
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<SpareCategories> query = _context.Set<SpareCategories>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Name.Value.Contains(normalized) ||
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
        IQueryable<SpareCategories> query = _context.Set<SpareCategories>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Name.Value.Contains(normalized) ||
                x.Description.Value.Contains(normalized));
        }

        return query.CountAsync(ct);
    }

    public Task AddAsync(SpareCategories entity, CancellationToken ct = default)
    {
        _context.Set<SpareCategories>().Add(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(SpareCategories entity, CancellationToken ct = default)
    {
        _context.Set<SpareCategories>().Update(entity);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(SpareCategories entity, CancellationToken ct = default)
    {
        _context.Set<SpareCategories>().Remove(entity);
        return Task.CompletedTask;
    }
}
