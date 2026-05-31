using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.Countries;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Countries;

public sealed class CountryRepository : ICountry
{
    private readonly AppDbContext _context;

    public CountryRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<Country?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return _context.Set<Country>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public Task<IReadOnlyList<Country>> GetAllAsync(CancellationToken ct = default)
    {
        return _context.Set<Country>()
            .AsNoTracking()
            .ToListAsync(ct)
            .ContinueWith(t => (IReadOnlyList<Country>)t.Result, ct);
    }

    public async Task<IReadOnlyList<Country>> GetPagedAsync(
        int page,
        int pageSize,
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<Country> query = _context.Set<Country>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Name.Value.Contains(normalized) ||
                x.Code.Value.Contains(normalized));
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
        IQueryable<Country> query = _context.Set<Country>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Name.Value.Contains(normalized) ||
                x.Code.Value.Contains(normalized));
        }

        return query.CountAsync(ct);
    }

    public Task AddAsync(Country country, CancellationToken ct = default)
    {
        _context.Set<Country>().Add(country);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Country country, CancellationToken ct = default)
    {
        _context.Set<Country>().Update(country);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(Country country, CancellationToken ct = default)
    {
        _context.Set<Country>().Remove(country);
        return Task.CompletedTask;
    }
}
