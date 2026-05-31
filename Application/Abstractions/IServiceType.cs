using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.ServiceType;

namespace Application.Abstractions;

public interface IServiceType
{
    Task<ServiceType?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<ServiceType>> GetAllAsync(CancellationToken ct = default);
    Task<IReadOnlyList<ServiceType>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);

    Task AddAsync(ServiceType entity, CancellationToken ct = default);
    Task UpdateAsync(ServiceType entity, CancellationToken ct = default);
    Task RemoveAsync(ServiceType entity, CancellationToken ct = default);
}
