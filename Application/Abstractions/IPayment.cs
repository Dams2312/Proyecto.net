using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.Payment;

namespace Application.Abstractions;

public interface IPayment
{
    Task<Payment?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<Payment>> GetAllAsync(CancellationToken ct = default);
    Task<IReadOnlyList<Payment>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);

    Task AddAsync(Payment entity, CancellationToken ct = default);
    Task UpdateAsync(Payment entity, CancellationToken ct = default);
    Task RemoveAsync(Payment entity, CancellationToken ct = default);
}
