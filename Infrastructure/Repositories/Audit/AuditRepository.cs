using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Audits = Domain.Entities.Audit.Audit;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Audit;

public sealed class AuditRepository : IAudit
{
    private readonly AppDbContext _context;

    public AuditRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<Audits?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return _context.Set<Audits>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public Task<IReadOnlyList<Audits>> GetAllAsync(CancellationToken ct = default)
    {
        return _context.Set<Audits>()
            .AsNoTracking()
            .ToListAsync(ct)
            .ContinueWith(t => (IReadOnlyList<Audits>)t.Result, ct);
    }

    public async Task<IReadOnlyList<Audits>> GetPagedAsync(
        int page,
        int pageSize,
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<Audits> query = _context.Set<Audits>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Entidad.Value.Contains(normalized) ||
                x.IpOrigen != null && x.IpOrigen.Value != null && x.IpOrigen.Value.Contains(normalized) ||
                x.DatosAnteriores != null && x.DatosAnteriores.Value != null && x.DatosAnteriores.Value.Contains(normalized) ||
                x.DatosNuevos != null && x.DatosNuevos.Value != null && x.DatosNuevos.Value.Contains(normalized));
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
        IQueryable<Audits> query = _context.Set<Audits>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Entidad.Value.Contains(normalized) ||
                x.IpOrigen != null && x.IpOrigen.Value != null && x.IpOrigen.Value.Contains(normalized) ||
                x.DatosAnteriores != null && x.DatosAnteriores.Value != null && x.DatosAnteriores.Value.Contains(normalized) ||
                x.DatosNuevos != null && x.DatosNuevos.Value != null && x.DatosNuevos.Value.Contains(normalized));
        }

        return query.CountAsync(ct);
    }

    public Task AddAsync(Audits audit, CancellationToken ct = default)
    {
        _context.Set<Audits>().Add(audit);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Audits audit, CancellationToken ct = default)
    {
        _context.Set<Audits>().Update(audit);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(Audits audit, CancellationToken ct = default)
    {
        _context.Set<Audits>().Remove(audit);
        return Task.CompletedTask;
    }
}
