using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using SparePartSuppliers = Domain.Entities.SparePartSupplier.SparePartSupplier;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.SparePartSupplier;

public sealed class SparePartSupplierRepository : ISparePartSupplier
{
    private readonly AppDbContext _context;

    public SparePartSupplierRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<SparePartSuppliers?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return _context.Set<SparePartSuppliers>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public Task<IReadOnlyList<SparePartSuppliers>> GetAllAsync(CancellationToken ct = default)
    {
        return _context.Set<SparePartSuppliers>()
            .AsNoTracking()
            .ToListAsync(ct)
            .ContinueWith(t => (IReadOnlyList<SparePartSuppliers>)t.Result, ct);
    }

    public async Task<IReadOnlyList<SparePartSuppliers>> GetPagedAsync(
        int page,
        int pageSize,
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<SparePartSuppliers> query = _context.Set<SparePartSuppliers>().AsNoTracking();

        return await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }

    public Task<int> CountAsync(
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<SparePartSuppliers> query = _context.Set<SparePartSuppliers>().AsNoTracking();
        return query.CountAsync(ct);
    }

    public Task AddAsync(SparePartSuppliers entity, CancellationToken ct = default)
    {
        _context.Set<SparePartSuppliers>().Add(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(SparePartSuppliers entity, CancellationToken ct = default)
    {
        _context.Set<SparePartSuppliers>().Update(entity);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(SparePartSuppliers entity, CancellationToken ct = default)
    {
        _context.Set<SparePartSuppliers>().Remove(entity);
        return Task.CompletedTask;
    }
}
