using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MileageHistories = Domain.Entities.MileageHistory.MileageHistory;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.MileageHistory;

public sealed class MileageHistoryRepository : IMileageHistory
{
    private readonly AppDbContext _context;

    public MileageHistoryRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<MileageHistories?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return _context.Set<MileageHistories>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public Task<IReadOnlyList<MileageHistories>> GetAllAsync(CancellationToken ct = default)
    {
        return _context.Set<MileageHistories>()
            .AsNoTracking()
            .ToListAsync(ct)
            .ContinueWith(t => (IReadOnlyList<MileageHistories>)t.Result, ct);
    }

    public async Task<IReadOnlyList<MileageHistories>> GetPagedAsync(
        int page,
        int pageSize,
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<MileageHistories> query = _context.Set<MileageHistories>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Source.Value.Contains(normalized));
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
        IQueryable<MileageHistories> query = _context.Set<MileageHistories>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Source.Value.Contains(normalized));
        }

        return query.CountAsync(ct);
    }

    public Task AddAsync(MileageHistories entity, CancellationToken ct = default)
    {
        _context.Set<MileageHistories>().Add(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(MileageHistories entity, CancellationToken ct = default)
    {
        _context.Set<MileageHistories>().Update(entity);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(MileageHistories entity, CancellationToken ct = default)
    {
        _context.Set<MileageHistories>().Remove(entity);
        return Task.CompletedTask;
    }
}
