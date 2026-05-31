using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using InvoiceStatuses = Domain.Entities.InvoiceStatus.InvoiceStatus;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.InvoiceStatus;

public sealed class InvoiceStatusRepository : IInvoiceStatus
{
    private readonly AppDbContext _context;

    public InvoiceStatusRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<InvoiceStatuses?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return _context.Set<InvoiceStatuses>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public Task<IReadOnlyList<InvoiceStatuses>> GetAllAsync(CancellationToken ct = default)
    {
        return _context.Set<InvoiceStatuses>()
            .AsNoTracking()
            .ToListAsync(ct)
            .ContinueWith(t => (IReadOnlyList<InvoiceStatuses>)t.Result, ct);
    }

    public async Task<IReadOnlyList<InvoiceStatuses>> GetPagedAsync(
        int page,
        int pageSize,
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<InvoiceStatuses> query = _context.Set<InvoiceStatuses>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Name.Value.Contains(normalized));
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
        IQueryable<InvoiceStatuses> query = _context.Set<InvoiceStatuses>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Name.Value.Contains(normalized));
        }

        return query.CountAsync(ct);
    }

    public Task AddAsync(InvoiceStatuses entity, CancellationToken ct = default)
    {
        _context.Set<InvoiceStatuses>().Add(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(InvoiceStatuses entity, CancellationToken ct = default)
    {
        _context.Set<InvoiceStatuses>().Update(entity);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(InvoiceStatuses entity, CancellationToken ct = default)
    {
        _context.Set<InvoiceStatuses>().Remove(entity);
        return Task.CompletedTask;
    }
}
