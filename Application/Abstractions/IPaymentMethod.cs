using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.PaymentMethod;

namespace Application.Abstractions;

public interface IPaymentMethod
{
    Task<PaymentMethod?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<PaymentMethod>> GetAllAsync(CancellationToken ct = default);
    Task<IReadOnlyList<PaymentMethod>> GetPagedAsync(int page, int pageSize, string? search = null, CancellationToken ct = default);
    Task<int> CountAsync(string? search = null, CancellationToken ct = default);

    Task AddAsync(PaymentMethod entity, CancellationToken ct = default);
    Task UpdateAsync(PaymentMethod entity, CancellationToken ct = default);
    Task RemoveAsync(PaymentMethod entity, CancellationToken ct = default);
}
