using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using OrderDetails = Domain.Entities.OrderDetail.OrderDetail;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.OrderDetail;

public sealed class OrderDetailRepository : IOrderDetail
{
    private readonly AppDbContext _context;

    public OrderDetailRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<OrderDetails?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return _context.Set<OrderDetails>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public Task<IReadOnlyList<OrderDetails>> GetAllAsync(CancellationToken ct = default)
    {
        return _context.Set<OrderDetails>()
            .AsNoTracking()
            .ToListAsync(ct)
            .ContinueWith(t => (IReadOnlyList<OrderDetails>)t.Result, ct);
    }

    public async Task<IReadOnlyList<OrderDetails>> GetPagedAsync(
        int page,
        int pageSize,
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<OrderDetails> query = _context.Set<OrderDetails>().AsNoTracking();

        return await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }

    public Task<int> CountAsync(
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<OrderDetails> query = _context.Set<OrderDetails>().AsNoTracking();
        return query.CountAsync(ct);
    }

    public Task AddAsync(OrderDetails entity, CancellationToken ct = default)
    {
        _context.Set<OrderDetails>().Add(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(OrderDetails entity, CancellationToken ct = default)
    {
        _context.Set<OrderDetails>().Update(entity);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(OrderDetails entity, CancellationToken ct = default)
    {
        _context.Set<OrderDetails>().Remove(entity);
        return Task.CompletedTask;
    }
}
