using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using CustomerAddresses = Domain.Entities.CustomerAddresses.CustomerAddress;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.CustomerAddress;

public sealed class CustomerAddressRepository : ICustomerAddress
{
    private readonly AppDbContext _context;

    public CustomerAddressRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<CustomerAddresses?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return _context.Set<CustomerAddresses>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public Task<IReadOnlyList<CustomerAddresses>> GetAllAsync(CancellationToken ct = default)
    {
        return _context.Set<CustomerAddresses>()
            .AsNoTracking()
            .ToListAsync(ct)
            .ContinueWith(t => (IReadOnlyList<CustomerAddresses>)t.Result, ct);
    }

    public async Task<IReadOnlyList<CustomerAddresses>> GetPagedAsync(
        int page,
        int pageSize,
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<CustomerAddresses> query = _context.Set<CustomerAddresses>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Street.Value.Contains(normalized));
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
        IQueryable<CustomerAddresses> query = _context.Set<CustomerAddresses>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Street.Value.Contains(normalized));
        }

        return query.CountAsync(ct);
    }

    public Task AddAsync(CustomerAddresses entity, CancellationToken ct = default)
    {
        _context.Set<CustomerAddresses>().Add(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(CustomerAddresses entity, CancellationToken ct = default)
    {
        _context.Set<CustomerAddresses>().Update(entity);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(CustomerAddresses entity, CancellationToken ct = default)
    {
        _context.Set<CustomerAddresses>().Remove(entity);
        return Task.CompletedTask;
    }
}
