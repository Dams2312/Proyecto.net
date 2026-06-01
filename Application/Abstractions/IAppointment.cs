using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.Appointment;

namespace Application.Abstractions;

public interface IAppointment
{
    Task<Appointment?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<Appointment>> GetAllAsync(CancellationToken ct = default);
    Task<IReadOnlyList<Appointment>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);

    Task AddAsync(Appointment entity, CancellationToken ct = default);
    Task UpdateAsync(Appointment entity, CancellationToken ct = default);
    Task RemoveAsync(Appointment entity, CancellationToken ct = default);
}
