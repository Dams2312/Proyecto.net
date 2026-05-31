using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using PaymentMethods = Domain.Entities.PaymentMethod.PaymentMethod;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.PaymentMethod;

public sealed class PaymentMethodRepository : IPaymentMethod
{
    private readonly AppDbContext _context;

    public PaymentMethodRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<PaymentMethods?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return _context.Set<PaymentMethods>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public Task<IReadOnlyList<PaymentMethods>> GetAllAsync(CancellationToken ct = default)
    {
        return _context.Set<PaymentMethods>()
            .AsNoTracking()
            .ToListAsync(ct)
            .ContinueWith(t => (IReadOnlyList<PaymentMethods>)t.Result, ct);
    }

    public async Task<IReadOnlyList<PaymentMethods>> GetPagedAsync(
        int page,
        int pageSize,
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<PaymentMethods> query = _context.Set<PaymentMethods>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Name.Value.Contains(normalized) ||
                x.Description.Value.Contains(normalized));
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
        IQueryable<PaymentMethods> query = _context.Set<PaymentMethods>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Name.Value.Contains(normalized) ||
                x.Description.Value.Contains(normalized));
        }

        return query.CountAsync(ct);
    }

    public Task AddAsync(PaymentMethods entity, CancellationToken ct = default)
    {
        _context.Set<PaymentMethods>().Add(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(PaymentMethods entity, CancellationToken ct = default)
    {
        _context.Set<PaymentMethods>().Update(entity);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(PaymentMethods entity, CancellationToken ct = default)
    {
        _context.Set<PaymentMethods>().Remove(entity);
        return Task.CompletedTask;
    }
}
