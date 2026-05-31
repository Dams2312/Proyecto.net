using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Vehicles = Domain.Entities.Vehicle.Vehicle;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Vehicle;

public sealed class VehicleRepository : IVehicle
{
    private readonly AppDbContext _context;

    public VehicleRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<Vehicles?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return _context.Set<Vehicles>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public Task<IReadOnlyList<Vehicles>> GetAllAsync(CancellationToken ct = default)
    {
        return _context.Set<Vehicles>()
            .AsNoTracking()
            .ToListAsync(ct)
            .ContinueWith(t => (IReadOnlyList<Vehicles>)t.Result, ct);
    }

    public async Task<IReadOnlyList<Vehicles>> GetPagedAsync(
        int page,
        int pageSize,
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<Vehicles> query = _context.Set<Vehicles>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Vin.Value.Contains(normalized) ||
                x.Plate.Value.Contains(normalized) ||
                x.Color.Value.Contains(normalized));
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
        IQueryable<Vehicles> query = _context.Set<Vehicles>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Vin.Value.Contains(normalized) ||
                x.Plate.Value.Contains(normalized) ||
                x.Color.Value.Contains(normalized));
        }

        return query.CountAsync(ct);
    }

    public Task AddAsync(Vehicles entity, CancellationToken ct = default)
    {
        _context.Set<Vehicles>().Add(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Vehicles entity, CancellationToken ct = default)
    {
        _context.Set<Vehicles>().Update(entity);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(Vehicles entity, CancellationToken ct = default)
    {
        _context.Set<Vehicles>().Remove(entity);
        return Task.CompletedTask;
    }
}
