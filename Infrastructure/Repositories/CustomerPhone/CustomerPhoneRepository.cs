using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using CustomerPhones = Domain.Entities.CustomerPhones.CustomerPhone;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.CustomerPhone;

public sealed class CustomerPhoneRepository : ICustomerPhone
{
    private readonly AppDbContext _context;

    public CustomerPhoneRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<CustomerPhones?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return _context.Set<CustomerPhones>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public Task<IReadOnlyList<CustomerPhones>> GetAllAsync(CancellationToken ct = default)
    {
        return _context.Set<CustomerPhones>()
            .AsNoTracking()
            .ToListAsync(ct)
            .ContinueWith(t => (IReadOnlyList<CustomerPhones>)t.Result, ct);
    }

    public async Task<IReadOnlyList<CustomerPhones>> GetPagedAsync(
        int page,
        int pageSize,
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<CustomerPhones> query = _context.Set<CustomerPhones>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.PhoneNumber.Value.Contains(normalized) ||
                x.PhoneType.Value.Contains(normalized));
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
        IQueryable<CustomerPhones> query = _context.Set<CustomerPhones>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.PhoneNumber.Value.Contains(normalized) ||
                x.PhoneType.Value.Contains(normalized));
        }

        return query.CountAsync(ct);
    }

    public Task AddAsync(CustomerPhones entity, CancellationToken ct = default)
    {
        _context.Set<CustomerPhones>().Add(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(CustomerPhones entity, CancellationToken ct = default)
    {
        _context.Set<CustomerPhones>().Update(entity);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(CustomerPhones entity, CancellationToken ct = default)
    {
        _context.Set<CustomerPhones>().Remove(entity);
        return Task.CompletedTask;
    }
}
