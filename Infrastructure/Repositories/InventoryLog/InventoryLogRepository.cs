using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using InventoryLogs = Domain.Entities.InventoryLog.InventoryLog;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.InventoryLog;

public sealed class InventoryLogRepository : IInventoryLog
{
    private readonly AppDbContext _context;

    public InventoryLogRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<InventoryLogs?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return _context.Set<InventoryLogs>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public Task<IReadOnlyList<InventoryLogs>> GetAllAsync(CancellationToken ct = default)
    {
        return _context.Set<InventoryLogs>()
            .AsNoTracking()
            .ToListAsync(ct)
            .ContinueWith(t => (IReadOnlyList<InventoryLogs>)t.Result, ct);
    }

    public async Task<IReadOnlyList<InventoryLogs>> GetPagedAsync(
        int page,
        int pageSize,
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<InventoryLogs> query = _context.Set<InventoryLogs>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.TypeMovement.Value.Contains(normalized) ||
                x.Motivo != null && x.Motivo.Value != null && x.Motivo.Value.Contains(normalized));
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
        IQueryable<InventoryLogs> query = _context.Set<InventoryLogs>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.TypeMovement.Value.Contains(normalized) ||
                x.Motivo != null && x.Motivo.Value != null && x.Motivo.Value.Contains(normalized));
        }

        return query.CountAsync(ct);
    }

    public Task AddAsync(InventoryLogs entity, CancellationToken ct = default)
    {
        _context.Set<InventoryLogs>().Add(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(InventoryLogs entity, CancellationToken ct = default)
    {
        _context.Set<InventoryLogs>().Update(entity);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(InventoryLogs entity, CancellationToken ct = default)
    {
        _context.Set<InventoryLogs>().Remove(entity);
        return Task.CompletedTask;
    }
}
