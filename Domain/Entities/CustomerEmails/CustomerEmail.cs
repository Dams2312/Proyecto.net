using System;
using Domain.common;
using Domain.ValueObject.CustomerEmail;

namespace Domain.Entities.CustomerEmails;

public sealed class CustomerEmail : BaseEntity<Guid>
{
    // FK COMO GUID
    public Guid CustomerId { get; private set; }

    public CustomerEmailAddress Address { get; private set; }

    public CustomerEmailPrimary Primary { get; private set; }

    private CustomerEmail() { }

    public CustomerEmail(
        Guid customerId,
        CustomerEmailAddress address,
        CustomerEmailPrimary primary)
    {
        if (customerId == Guid.Empty)
            throw new ArgumentException("El id del cliente es obligatorio.", nameof(customerId));

        CustomerId = customerId;

        Address = address ?? throw new ArgumentNullException(nameof(address));
        Primary = primary ?? throw new ArgumentNullException(nameof(primary));
    }

    public void UpdateCustomerId(Guid customerId)
    {
        if (customerId == Guid.Empty)
            throw new ArgumentException("El id del cliente es obligatorio.", nameof(customerId));

        CustomerId = customerId;
    }

    public void UpdateAddress(CustomerEmailAddress address)
    {
        Address = address ?? throw new ArgumentNullException(nameof(address));
    }

    public void UpdatePrimary(CustomerEmailPrimary primary)
    {
        Primary = primary ?? throw new ArgumentNullException(nameof(primary));
    }
}