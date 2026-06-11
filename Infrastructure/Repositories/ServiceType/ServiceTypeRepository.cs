using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using ServiceTypes = Domain.Entities.ServiceType.ServiceType;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.ServiceType;

public sealed class ServiceTypeRepository : IServiceType
{
    private readonly AppDbContext _context;

    public ServiceTypeRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<ServiceTypes?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return _context.Set<ServiceTypes>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public Task<IReadOnlyList<ServiceTypes>> GetAllAsync(CancellationToken ct = default)
    {
        return _context.Set<ServiceTypes>()
            .AsNoTracking()
            .ToListAsync(ct)
            .ContinueWith(t => (IReadOnlyList<ServiceTypes>)t.Result, ct);
    }

    public async Task<IReadOnlyList<ServiceTypes>> GetPagedAsync(
        int page,
        int pageSize,
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<ServiceTypes> query = _context.Set<ServiceTypes>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Name.Value.Contains(normalized) ||
                x.Description != null && x.Description.Value != null && x.Description.Value.Contains(normalized));
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
        IQueryable<ServiceTypes> query = _context.Set<ServiceTypes>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Name.Value.Contains(normalized) ||
                x.Description != null && x.Description.Value != null && x.Description.Value.Contains(normalized));
        }

        return query.CountAsync(ct);
    }

    public Task AddAsync(ServiceTypes entity, CancellationToken ct = default)
    {
        _context.Set<ServiceTypes>().Add(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(ServiceTypes entity, CancellationToken ct = default)
    {
        _context.Set<ServiceTypes>().Update(entity);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(ServiceTypes entity, CancellationToken ct = default)
    {
        _context.Set<ServiceTypes>().Remove(entity);
        return Task.CompletedTask;
    }
}
