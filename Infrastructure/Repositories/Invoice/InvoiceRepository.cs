using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Invoices = Domain.Entities.Invoice.Invoice;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Invoice;

public sealed class InvoiceRepository : IInvoice
{
    private readonly AppDbContext _context;

    public InvoiceRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<Invoices?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return _context.Set<Invoices>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public Task<IReadOnlyList<Invoices>> GetAllAsync(CancellationToken ct = default)
    {
        return _context.Set<Invoices>()
            .AsNoTracking()
            .ToListAsync(ct)
            .ContinueWith(t => (IReadOnlyList<Invoices>)t.Result, ct);
    }

    public async Task<IReadOnlyList<Invoices>> GetPagedAsync(
        int page,
        int pageSize,
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<Invoices> query = _context.Set<Invoices>().AsNoTracking();

        return await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }

    public Task<int> CountAsync(
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<Invoices> query = _context.Set<Invoices>().AsNoTracking();
        return query.CountAsync(ct);
    }

    public Task AddAsync(Invoices entity, CancellationToken ct = default)
    {
        _context.Set<Invoices>().Add(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Invoices entity, CancellationToken ct = default)
    {
        _context.Set<Invoices>().Update(entity);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(Invoices entity, CancellationToken ct = default)
    {
        _context.Set<Invoices>().Remove(entity);
        return Task.CompletedTask;
    }
}
