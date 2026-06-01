using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Users = Domain.Entities.Users.User;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.User;

public sealed class UserRepository : IUser
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<Users?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return _context.Set<Users>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public Task<IReadOnlyList<Users>> GetAllAsync(CancellationToken ct = default)
    {
        return _context.Set<Users>()
            .AsNoTracking()
            .ToListAsync(ct)
            .ContinueWith(t => (IReadOnlyList<Users>)t.Result, ct);
    }

    public async Task<IReadOnlyList<Users>> GetPagedAsync(
        int page,
        int pageSize,
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<Users> query = _context.Set<Users>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Code.Value.Contains(normalized) ||
                x.Names.Value.Contains(normalized) ||
                x.Surnames.Value.Contains(normalized) ||
                x.Mail.Value.Contains(normalized));
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
        IQueryable<Users> query = _context.Set<Users>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Code.Value.Contains(normalized) ||
                x.Names.Value.Contains(normalized) ||
                x.Surnames.Value.Contains(normalized) ||
                x.Mail.Value.Contains(normalized));
        }

        return query.CountAsync(ct);
    }

    public Task AddAsync(Users entity, CancellationToken ct = default)
    {
        _context.Set<Users>().Add(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Users entity, CancellationToken ct = default)
    {
        _context.Set<Users>().Update(entity);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(Users entity, CancellationToken ct = default)
    {
        _context.Set<Users>().Remove(entity);
        return Task.CompletedTask;
    }
}
