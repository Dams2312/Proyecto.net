using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.Vehiclemodel;

namespace Application.Abstractions;

public interface IVehicleModel
{
    Task<VehicleModel?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<VehicleModel>> GetAllAsync(CancellationToken ct = default);
    Task<IReadOnlyList<VehicleModel>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);

    Task AddAsync(VehicleModel entity, CancellationToken ct = default);
    Task UpdateAsync(VehicleModel entity, CancellationToken ct = default);
    Task RemoveAsync(VehicleModel entity, CancellationToken ct = default);
}
