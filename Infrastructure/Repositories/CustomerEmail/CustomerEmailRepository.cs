using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using CustomerEmails = Domain.Entities.CustomerEmails.CustomerEmail;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.CustomerEmail;

public sealed class CustomerEmailRepository : ICustomerEmail
{
    private readonly AppDbContext _context;

    public CustomerEmailRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<CustomerEmails?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return _context.Set<CustomerEmails>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public Task<IReadOnlyList<CustomerEmails>> GetAllAsync(CancellationToken ct = default)
    {
        return _context.Set<CustomerEmails>()
            .AsNoTracking()
            .ToListAsync(ct)
            .ContinueWith(t => (IReadOnlyList<CustomerEmails>)t.Result, ct);
    }

    public async Task<IReadOnlyList<CustomerEmails>> GetPagedAsync(
        int page,
        int pageSize,
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<CustomerEmails> query = _context.Set<CustomerEmails>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Address.Value.Contains(normalized));
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
        IQueryable<CustomerEmails> query = _context.Set<CustomerEmails>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Address.Value.Contains(normalized));
        }

        return query.CountAsync(ct);
    }

    public Task AddAsync(CustomerEmails entity, CancellationToken ct = default)
    {
        _context.Set<CustomerEmails>().Add(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(CustomerEmails entity, CancellationToken ct = default)
    {
        _context.Set<CustomerEmails>().Update(entity);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(CustomerEmails entity, CancellationToken ct = default)
    {
        _context.Set<CustomerEmails>().Remove(entity);
        return Task.CompletedTask;
    }
}
