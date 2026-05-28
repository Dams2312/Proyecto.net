using System;
using Domain.common;
using Domain.ValueObject.InvoiceStatus;

namespace Domain.Entities.InvoiceStatus;

public sealed class InvoiceStatus : BaseEntity<Guid>
{
    public InvoiceStatusName Name { get; private set; }

    private InvoiceStatus() { }

    public InvoiceStatus(InvoiceStatusName name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public void UpdateName(InvoiceStatusName name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }
}
