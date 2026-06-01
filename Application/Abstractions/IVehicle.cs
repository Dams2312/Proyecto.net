using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.Vehicle;

namespace Application.Abstractions;

public interface IVehicle
{
    Task<Vehicle?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<Vehicle>> GetAllAsync(CancellationToken ct = default);
    Task<IReadOnlyList<Vehicle>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);

    Task AddAsync(Vehicle entity, CancellationToken ct = default);
    Task UpdateAsync(Vehicle entity, CancellationToken ct = default);
    Task RemoveAsync(Vehicle entity, CancellationToken ct = default);
}
