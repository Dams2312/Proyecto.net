using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.InvoiceStatus;

namespace Application.Abstractions;

public interface IInvoiceStatus
{
    Task<InvoiceStatus?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<InvoiceStatus>> GetAllAsync(CancellationToken ct = default);
    Task<IReadOnlyList<InvoiceStatus>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);

    Task AddAsync(InvoiceStatus entity, CancellationToken ct = default);
    Task UpdateAsync(InvoiceStatus entity, CancellationToken ct = default);
    Task RemoveAsync(InvoiceStatus entity, CancellationToken ct = default);
}
