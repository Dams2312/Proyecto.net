using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.Departments;

namespace Application.Abstractions;

public interface IDepartment
{
    Task<Department?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<Department>> GetAllAsync(CancellationToken ct = default);
    Task<IReadOnlyList<Department>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);

    Task AddAsync(Department entity, CancellationToken ct = default);
    Task UpdateAsync(Department entity, CancellationToken ct = default);
    Task RemoveAsync(Department entity, CancellationToken ct = default);
}
