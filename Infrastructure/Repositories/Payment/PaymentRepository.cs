using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Payments = Domain.Entities.Payment.Payment;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Payment;

public sealed class PaymentRepository : IPayment
{
    private readonly AppDbContext _context;

    public PaymentRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<Payments?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return _context.Set<Payments>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public Task<IReadOnlyList<Payments>> GetAllAsync(CancellationToken ct = default)
    {
        return _context.Set<Payments>()
            .AsNoTracking()
            .ToListAsync(ct)
            .ContinueWith(t => (IReadOnlyList<Payments>)t.Result, ct);
    }

    public async Task<IReadOnlyList<Payments>> GetPagedAsync(
        int page,
        int pageSize,
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<Payments> query = _context.Set<Payments>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Referencia != null && x.Referencia.Value != null && x.Referencia.Value.Contains(normalized) ||
                x.Estado.Value.Contains(normalized));
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
        IQueryable<Payments> query = _context.Set<Payments>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Referencia != null && x.Referencia.Value != null && x.Referencia.Value.Contains(normalized) ||
                x.Estado.Value.Contains(normalized));
        }

        return query.CountAsync(ct);
    }

    public Task AddAsync(Payments entity, CancellationToken ct = default)
    {
        _context.Set<Payments>().Add(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Payments entity, CancellationToken ct = default)
    {
        _context.Set<Payments>().Update(entity);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(Payments entity, CancellationToken ct = default)
    {
        _context.Set<Payments>().Remove(entity);
        return Task.CompletedTask;
    }
}
