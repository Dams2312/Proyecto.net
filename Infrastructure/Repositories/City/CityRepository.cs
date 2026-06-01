using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Cityes =  Domain.Entities.Citys.City;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.City;

public sealed class CityRepository : ICity
{
    private readonly AppDbContext _context;

    public CityRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<Cityes?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return _context.Set<Cityes>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public Task<IReadOnlyList<Cityes>> GetAllAsync(CancellationToken ct = default)
    {
        return _context.Set<Cityes>()
            .AsNoTracking()
            .ToListAsync(ct)
            .ContinueWith(t => (IReadOnlyList<Cityes>)t.Result, ct);
    }

    public async Task<IReadOnlyList<Cityes>> GetPagedAsync(
        int page,
        int pageSize,
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<Cityes> query = _context.Set<Cityes>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Name.Contains(normalized) ||
                x.Code.Contains(normalized));
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
        IQueryable<Cityes> query = _context.Set<Cityes>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Name.Contains(normalized) ||
                x.Code.Contains(normalized));
        }

        return query.CountAsync(ct);
    }

    public Task AddAsync(Cityes city, CancellationToken ct = default)
    {
        _context.Set<Cityes>().Add(city);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Cityes city, CancellationToken ct = default)
    {
        _context.Set<Cityes>().Update(city);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(Cityes city, CancellationToken ct = default)
    {
        _context.Set<Cityes>().Remove(city);
        return Task.CompletedTask;
    }
}
