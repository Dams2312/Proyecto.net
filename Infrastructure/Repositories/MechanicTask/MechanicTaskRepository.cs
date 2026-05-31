using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MechanicTasks = Domain.Entities.MechanicTask.MechanicTask;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.MechanicTask;

public sealed class MechanicTaskRepository : IMechanicTask
{
    private readonly AppDbContext _context;

    public MechanicTaskRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<MechanicTasks?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return _context.Set<MechanicTasks>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public Task<IReadOnlyList<MechanicTasks>> GetAllAsync(CancellationToken ct = default)
    {
        return _context.Set<MechanicTasks>()
            .AsNoTracking()
            .ToListAsync(ct)
            .ContinueWith(t => (IReadOnlyList<MechanicTasks>)t.Result, ct);
    }

    public async Task<IReadOnlyList<MechanicTasks>> GetPagedAsync(
        int page,
        int pageSize,
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<MechanicTasks> query = _context.Set<MechanicTasks>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Description.Value.Contains(normalized) ||
                x.Status.Value.Contains(normalized));
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
        IQueryable<MechanicTasks> query = _context.Set<MechanicTasks>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Description.Value.Contains(normalized) ||
                x.Status.Value.Contains(normalized));
        }

        return query.CountAsync(ct);
    }

    public Task AddAsync(MechanicTasks entity, CancellationToken ct = default)
    {
        _context.Set<MechanicTasks>().Add(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(MechanicTasks entity, CancellationToken ct = default)
    {
        _context.Set<MechanicTasks>().Update(entity);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(MechanicTasks entity, CancellationToken ct = default)
    {
        _context.Set<MechanicTasks>().Remove(entity);
        return Task.CompletedTask;
    }
}
