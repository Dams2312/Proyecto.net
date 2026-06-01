using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using VehicleMakes = Domain.Entities.VehicleMake.VehicleMake;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.VehicleMake;

public sealed class VehicleMakeRepository : IVehicleMake
{
    private readonly AppDbContext _context;

    public VehicleMakeRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<VehicleMakes?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return _context.Set<VehicleMakes>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public Task<IReadOnlyList<VehicleMakes>> GetAllAsync(CancellationToken ct = default)
    {
        return _context.Set<VehicleMakes>()
            .AsNoTracking()
            .ToListAsync(ct)
            .ContinueWith(t => (IReadOnlyList<VehicleMakes>)t.Result, ct);
    }

    public async Task<IReadOnlyList<VehicleMakes>> GetPagedAsync(
        int page,
        int pageSize,
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<VehicleMakes> query = _context.Set<VehicleMakes>().AsNoTracking();

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
        IQueryable<VehicleMakes> query = _context.Set<VehicleMakes>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Name.Value.Contains(normalized));
        }

        return query.CountAsync(ct);
    }

    public Task AddAsync(VehicleMakes entity, CancellationToken ct = default)
    {
        _context.Set<VehicleMakes>().Add(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(VehicleMakes entity, CancellationToken ct = default)
    {
        _context.Set<VehicleMakes>().Update(entity);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(VehicleMakes entity, CancellationToken ct = default)
    {
        _context.Set<VehicleMakes>().Remove(entity);
        return Task.CompletedTask;
    }
}
