using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Appoinments = Domain.Entities.Appointment.Appointment;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Appointment;

public sealed class AppointmentRepository : IAppointment
{
    private readonly AppDbContext _context;

    public AppointmentRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<Appoinments?> GetByIdAsync(Guid id, CancellationToken ct = default)
    {
        return _context.Set<Appoinments>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public Task<IReadOnlyList<Appoinments>> GetAllAsync(CancellationToken ct = default)
    {
        return _context.Set<Appoinments>()
            .AsNoTracking()
            .ToListAsync(ct)
            .ContinueWith(t => (IReadOnlyList<Appoinments>)t.Result, ct);
    }

    public async Task<IReadOnlyList<Appoinments>> GetPagedAsync(
        int page,
        int pageSize,
        string? search = null,
        CancellationToken ct = default)
    {
        IQueryable<Appoinments> query = _context.Set<Appoinments>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Observations != null && x.Observations.Value != null && x.Observations.Value.Contains(normalized));
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
        IQueryable<Appoinments> query = _context.Set<Appoinments>().AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var normalized = search.Trim().ToLower();

            query = query.Where(x =>
                x.Observations != null && x.Observations.Value != null && x.Observations.Value.Contains(normalized));
        }

        return query.CountAsync(ct);
    }

    public Task AddAsync(Appoinments appointment, CancellationToken ct = default)
    {
        _context.Set<Appoinments>().Add(appointment);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Appoinments appointment, CancellationToken ct = default)
    {
        _context.Set<Appoinments>().Update(appointment);
        return Task.CompletedTask;
    }

    public Task RemoveAsync(Appoinments appointment, CancellationToken ct = default)
    {
        _context.Set<Appoinments>().Remove(appointment);
        return Task.CompletedTask;
    }
}
