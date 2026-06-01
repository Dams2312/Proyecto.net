using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using PurchaseDetails = Domain.Entities.PurchaseDetail.PurchaseDetail;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.PurchaseDetail;

public sealed class PurchaseDetailRepository : IPurchaseDetail
{
    private readonly AppDbContext _context;

    public PurchaseDetailRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<PurchaseDetails?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return _context.Set<PurchaseDetails>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public Task<IReadOnlyList<PurchaseDetails>> GetAllAsync(CancellationToken ct = default)
    {
        return _context.Set<PurchaseDetails>()
            .AsNoTracking()
            .ToListAsync(ct)
            .ContinueWith(t => (IReadOnlyList<PurchaseDetails>)t.Result, ct);
    }

    public async Task<IReadOnlyList<PurchaseDetails>> GetPagedAsync(
        int page,
        int pageSize,
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<PurchaseDetails> query = _context.Set<PurchaseDetails>().AsNoTracking();

        return await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }

    public Task<int> CountAsync(
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<PurchaseDetails> query = _context.Set<PurchaseDetails>().AsNoTracking();
        return query.CountAsync(ct);
    }

    public Task AddAsync(PurchaseDetails entity, CancellationToken ct = default)
    {
        _context.Set<PurchaseDetails>().Add(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(PurchaseDetails entity, CancellationToken ct = default)
    {
        _context.Set<PurchaseDetails>().Update(entity);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(PurchaseDetails entity, CancellationToken ct = default)
    {
        _context.Set<PurchaseDetails>().Remove(entity);
        return Task.CompletedTask;
    }
}
