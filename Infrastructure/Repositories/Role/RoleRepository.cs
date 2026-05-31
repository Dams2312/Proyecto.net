using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Roles = Domain.Entities.Roles.Role;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Role;

public sealed class RoleRepository : IRole
{
    private readonly AppDbContext _context;

    public RoleRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<Roles?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return _context.Set<Roles>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public Task<IReadOnlyList<Roles>> GetAllAsync(CancellationToken ct = default)
    {
        return _context.Set<Roles>()
            .AsNoTracking()
            .ToListAsync(ct)
            .ContinueWith(t => (IReadOnlyList<Roles>)t.Result, ct);
    }

    public async Task<IReadOnlyList<Roles>> GetPagedAsync(
        int page,
        int pageSize,
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<Roles> query = _context.Set<Roles>().AsNoTracking();

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
        IQueryable<Roles> query = _context.Set<Roles>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Name.Value.Contains(normalized) ||
                x.Description.Value.Contains(normalized));
        }

        return query.CountAsync(ct);
    }

    public Task AddAsync(Roles entity, CancellationToken ct = default)
    {
        _context.Set<Roles>().Add(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Roles entity, CancellationToken ct = default)
    {
        _context.Set<Roles>().Update(entity);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(Roles entity, CancellationToken ct = default)
    {
        _context.Set<Roles>().Remove(entity);
        return Task.CompletedTask;
    }
}
