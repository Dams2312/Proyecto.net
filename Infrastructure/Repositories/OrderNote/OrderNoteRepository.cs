using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using OrderNotes = Domain.Entities.OrderNote.OrderNote;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.OrderNote;

public sealed class OrderNoteRepository : IOrderNote
{
    private readonly AppDbContext _context;

    public OrderNoteRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<OrderNotes?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return _context.Set<OrderNotes>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public Task<IReadOnlyList<OrderNotes>> GetAllAsync(CancellationToken ct = default)
    {
        return _context.Set<OrderNotes>()
            .AsNoTracking()
            .ToListAsync(ct)
            .ContinueWith(t => (IReadOnlyList<OrderNotes>)t.Result, ct);
    }

    public async Task<IReadOnlyList<OrderNotes>> GetPagedAsync(
        int page,
        int pageSize,
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<OrderNotes> query = _context.Set<OrderNotes>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Content.Value.Contains(normalized));
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
        IQueryable<OrderNotes> query = _context.Set<OrderNotes>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Content.Value.Contains(normalized));
        }

        return query.CountAsync(ct);
    }

    public Task AddAsync(OrderNotes entity, CancellationToken ct = default)
    {
        _context.Set<OrderNotes>().Add(entity);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(OrderNotes entity, CancellationToken ct = default)
    {
        _context.Set<OrderNotes>().Update(entity);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(OrderNotes entity, CancellationToken ct = default)
    {
        _context.Set<OrderNotes>().Remove(entity);
        return Task.CompletedTask;
    }
}
