using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.Roles;

namespace Application.Abstractions;

public interface IRole
{
    Task<Role?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<Role>> GetAllAsync(CancellationToken ct = default);
    Task<IReadOnlyList<Role>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);

    Task AddAsync(Role entity, CancellationToken ct = default);
    Task UpdateAsync(Role entity, CancellationToken ct = default);
    Task RemoveAsync(Role entity, CancellationToken ct = default);
}
