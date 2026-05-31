using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Customers = Domain.Entities.Customers.Customer;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Customer;

public sealed class CustomerRepository : ICustomer
{
    private readonly AppDbContext _context;

    public CustomerRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<Customers?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return _context.Set<Customers>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public Task<IReadOnlyList<Customers>> GetAllAsync(CancellationToken ct = default)
    {
        return _context.Set<Customers>()
            .AsNoTracking()
            .ToListAsync(ct)
            .ContinueWith(t => (IReadOnlyList<Customers>)t.Result, ct);
    }

    public async Task<IReadOnlyList<Customers>> GetPagedAsync(
        int page,
        int pageSize,
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<Customers> query = _context.Set<Customers>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Names.Value.Contains(normalized) ||
                x.Surnames.Value.Contains(normalized) ||
                x.DocumentNumber.Value.Contains(normalized));
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
        IQueryable<Customers> query = _context.Set<Customers>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Names.Value.Contains(normalized) ||
                x.Surnames.Value.Contains(normalized) ||
                x.DocumentNumber.Value.Contains(normalized));
        }

        return query.CountAsync(ct);
    }

    public Task AddAsync(Customers customer, CancellationToken ct = default)
    {
        _context.Set<Customers>().Add(customer);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Customers customer, CancellationToken ct = default)
    {
        _context.Set<Customers>().Update(customer);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(Customers customer, CancellationToken ct = default)
    {
        _context.Set<Customers>().Remove(customer);
        return Task.CompletedTask;
    }
}
