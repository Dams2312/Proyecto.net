using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using VehicleModels = Domain.Entities.Vehiclemodel.VehicleModel;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.VehicleModel;

public sealed class VehicleModelRepository : IVehicleModel
{
    private readonly AppDbContext _context;

    public VehicleModelRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<VehicleModels?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return _context.Set<VehicleModels>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public Task<IReadOnlyList<VehicleModels>> GetAllAsync(CancellationToken ct = default)
    {
        return _context.Set<VehicleModels>()
            .AsNoTracking()
            .ToListAsync(ct)
            .ContinueWith(t => (IReadOnlyList<VehicleModels>)t.Result, ct);
    }

    public async Task<IReadOnlyList<VehicleModels>> GetPagedAsync(
        int page,
        int pageSize,
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<VehicleModels> query = _context.Set<VehicleModels>().AsNoTracking();

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
        IQueryable<VehicleModels> query = _context.Set<VehicleModels>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Name.Value.Contains(normalized));
        }

        return query.CountAsync(ct);
    }

    public Task AddAsync(VehicleModels entity, CancellationToken ct = default)
    {
        _context.Set<VehicleModels>().Add(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(VehicleModels entity, CancellationToken ct = default)
    {
        _context.Set<VehicleModels>().Update(entity);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(VehicleModels entity, CancellationToken ct = default)
    {
        _context.Set<VehicleModels>().Remove(entity);
        return Task.CompletedTask;
    }
}
