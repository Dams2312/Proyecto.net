using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Departments = Domain.Entities.Departments.Department;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Department;

public sealed class DepartmentRepository : IDepartment
{
    private readonly AppDbContext _context;

    public DepartmentRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<Departments?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return _context.Set<Departments>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public Task<IReadOnlyList<Departments>> GetAllAsync(CancellationToken ct = default)
    {
        return _context.Set<Departments>()
            .AsNoTracking()
            .ToListAsync(ct)
            .ContinueWith(t => (IReadOnlyList<Departments>)t.Result, ct);
    }

    public async Task<IReadOnlyList<Departments>> GetPagedAsync(
        int page,
        int pageSize,
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<Departments> query = _context.Set<Departments>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Name.Value.Contains(normalized) ||
                x.Code.Value.Contains(normalized));
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
        IQueryable<Departments> query = _context.Set<Departments>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Name.Value.Contains(normalized) ||
                x.Code.Value.Contains(normalized));
        }

        return query.CountAsync(ct);
    }

    public Task AddAsync(Departments entity, CancellationToken ct = default)
    {
        _context.Set<Departments>().Add(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Departments entity, CancellationToken ct = default)
    {
        _context.Set<Departments>().Update(entity);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(Departments entity, CancellationToken ct = default)
    {
        _context.Set<Departments>().Remove(entity);
        return Task.CompletedTask;
    }
}
