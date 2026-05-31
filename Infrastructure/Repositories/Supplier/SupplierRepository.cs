using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Suppliers = Domain.Entities.Supplier.Supplier;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Supplier;

public sealed class SupplierRepository : ISupplier
{
    private readonly AppDbContext _context;

    public SupplierRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<Suppliers?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return _context.Set<Suppliers>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public Task<IReadOnlyList<Suppliers>> GetAllAsync(CancellationToken ct = default)
    {
        return _context.Set<Suppliers>()
            .AsNoTracking()
            .ToListAsync(ct)
            .ContinueWith(t => (IReadOnlyList<Suppliers>)t.Result, ct);
    }

    public async Task<IReadOnlyList<Suppliers>> GetPagedAsync(
        int page,
        int pageSize,
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<Suppliers> query = _context.Set<Suppliers>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Name.Value.Contains(normalized) ||
                x.Nit.Value.Contains(normalized) ||
                x.Email.Value.Contains(normalized) ||
                x.Phone.Value.Contains(normalized));
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
        IQueryable<Suppliers> query = _context.Set<Suppliers>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Name.Value.Contains(normalized) ||
                x.Nit.Value.Contains(normalized) ||
                x.Email.Value.Contains(normalized) ||
                x.Phone.Value.Contains(normalized));
        }

        return query.CountAsync(ct);
    }

    public Task AddAsync(Suppliers entity, CancellationToken ct = default)
    {
        _context.Set<Suppliers>().Add(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Suppliers entity, CancellationToken ct = default)
    {
        _context.Set<Suppliers>().Update(entity);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(Suppliers entity, CancellationToken ct = default)
    {
        _context.Set<Suppliers>().Remove(entity);
        return Task.CompletedTask;
    }
}
