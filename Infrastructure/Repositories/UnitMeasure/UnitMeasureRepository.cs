using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using UnitMeasures = Domain.Entities.UnitMeasure.UnitMeasure;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.UnitMeasure;

public sealed class UnitMeasureRepository : IUnitMeasure
{
    private readonly AppDbContext _context;

    public UnitMeasureRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<UnitMeasures?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return _context.Set<UnitMeasures>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public Task<IReadOnlyList<UnitMeasures>> GetAllAsync(CancellationToken ct = default)
    {
        return _context.Set<UnitMeasures>()
            .AsNoTracking()
            .ToListAsync(ct)
            .ContinueWith(t => (IReadOnlyList<UnitMeasures>)t.Result, ct);
    }

    public async Task<IReadOnlyList<UnitMeasures>> GetPagedAsync(
        int page,
        int pageSize,
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<UnitMeasures> query = _context.Set<UnitMeasures>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Name.Value.Contains(normalized) ||
                x.Abbreviation.Value.Contains(normalized));
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
        IQueryable<UnitMeasures> query = _context.Set<UnitMeasures>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Name.Value.Contains(normalized) ||
                x.Abbreviation.Value.Contains(normalized));
        }

        return query.CountAsync(ct);
    }

    public Task AddAsync(UnitMeasures entity, CancellationToken ct = default)
    {
        _context.Set<UnitMeasures>().Add(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(UnitMeasures entity, CancellationToken ct = default)
    {
        _context.Set<UnitMeasures>().Update(entity);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(UnitMeasures entity, CancellationToken ct = default)
    {
        _context.Set<UnitMeasures>().Remove(entity);
        return Task.CompletedTask;
    }
}
