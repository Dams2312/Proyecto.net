using System;
using Domain.common;
using Domain.ValueObject.Purchase;

namespace Domain.Entities.Purchase;

public sealed class Purchase : BaseEntity<Guid>
{
    public PurchaseDate Date { get; private set; }
    public PurchaseSupplierId SupplierId { get; private set; }
    public PurchaseUserId UserId { get; private set; }
    public PurchaseStatus Status { get; private set; }
    public PurchaseObservations Observations { get; private set; }
    public PurchaseTotal Total { get; private set; }

    private Purchase() { }

    public Purchase(
        PurchaseDate date,
        PurchaseSupplierId supplierId,
        PurchaseUserId userId,
        PurchaseStatus status,
        PurchaseObservations observations,
        PurchaseTotal total)
    {
        Date = date ?? throw new ArgumentNullException(nameof(date));
        SupplierId = supplierId ?? throw new ArgumentNullException(nameof(supplierId));
        UserId = userId ?? throw new ArgumentNullException(nameof(userId));
        Status = status ?? throw new ArgumentNullException(nameof(status));
        Observations = observations ?? throw new ArgumentNullException(nameof(observations));
        Total = total ?? throw new ArgumentNullException(nameof(total));
    }

    public void UpdateDate(PurchaseDate date)
    {
        Date = date ?? throw new ArgumentNullException(nameof(date));
    }

    public void UpdateSupplierId(PurchaseSupplierId supplierId)
    {
        SupplierId = supplierId ?? throw new ArgumentNullException(nameof(supplierId));
    }

    public void UpdateUserId(PurchaseUserId userId)
    {
        UserId = userId ?? throw new ArgumentNullException(nameof(userId));
    }

    public void UpdateStatus(PurchaseStatus status)
    {
        Status = status ?? throw new ArgumentNullException(nameof(status));
    }

    public void UpdateObservations(PurchaseObservations observations)
    {
        Observations = observations ?? throw new ArgumentNullException(nameof(observations));
    }

    public void UpdateTotal(PurchaseTotal total)
    {
        Total = total ?? throw new ArgumentNullException(nameof(total));
    }
}
