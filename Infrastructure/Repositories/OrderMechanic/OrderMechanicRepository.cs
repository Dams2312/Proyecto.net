using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using OrderMechanics = Domain.Entities.OrderMechanic.OrderMechanic;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.OrderMechanic;

public sealed class OrderMechanicRepository : IOrderMechanic
{
    private readonly AppDbContext _context;

    public OrderMechanicRepository(AppDbContext context)
    {
        _context = context;
    }

   public Task<OrderMechanics?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return _context.Set<OrderMechanics>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.OrderId.Value == id, ct);
    }

    public Task<IReadOnlyList<OrderMechanics>> GetAllAsync(CancellationToken ct = default)
    {
        return _context.Set<OrderMechanics>()
            .AsNoTracking()
            .ToListAsync(ct)
            .ContinueWith(t => (IReadOnlyList<OrderMechanics>)t.Result, ct);
    }

    public async Task<IReadOnlyList<OrderMechanics>> GetPagedAsync(
        int page,
        int pageSize,
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<OrderMechanics> query = _context.Set<OrderMechanics>().AsNoTracking();

        return await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(ct);
    }

    public Task<int> CountAsync(
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<OrderMechanics> query = _context.Set<OrderMechanics>().AsNoTracking();
        return query.CountAsync(ct);
    }

    public Task AddAsync(OrderMechanics entity, CancellationToken ct = default)
    {
        _context.Set<OrderMechanics>().Add(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(OrderMechanics entity, CancellationToken ct = default)
    {
        _context.Set<OrderMechanics>().Update(entity);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(OrderMechanics entity, CancellationToken ct = default)
    {
        _context.Set<OrderMechanics>().Remove(entity);
        return Task.CompletedTask;
    }
}
