using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.Invoice;

namespace Application.Abstractions;

public interface IInvoice
{
    Task<Invoice?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<Invoice>> GetAllAsync(CancellationToken ct = default);
    Task<IReadOnlyList<Invoice>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);

    Task AddAsync(Invoice entity, CancellationToken ct = default);
    Task UpdateAsync(Invoice entity, CancellationToken ct = default);
    Task RemoveAsync(Invoice entity, CancellationToken ct = default);
}
