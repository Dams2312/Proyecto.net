using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.VehicleMake;

namespace Application.Abstractions;

public interface IVehicleMake
{
    Task<VehicleMake?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<VehicleMake>> GetAllAsync(CancellationToken ct = default);
    Task<IReadOnlyList<VehicleMake>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);

    Task AddAsync(VehicleMake entity, CancellationToken ct = default);
    Task UpdateAsync(VehicleMake entity, CancellationToken ct = default);
    Task RemoveAsync(VehicleMake entity, CancellationToken ct = default);
}
