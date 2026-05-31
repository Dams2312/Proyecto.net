using System;
using Domain.common;
using Domain.ValueObject.CustomerAddress;

namespace Domain.Entities.CustomerAddresses;

public sealed class CustomerAddress : BaseEntity<Guid>
{
    // FK COMO GUID
    public Guid CustomerId { get; private set; }

    public CustomerAddressStreet Street { get; private set; }

    public CustomerAddressPrimary Primary { get; private set; }

    private CustomerAddress() { }

    public CustomerAddress(
        Guid customerId,
        CustomerAddressStreet street,
        CustomerAddressPrimary primary)
    {
        if (customerId == Guid.Empty)
            throw new ArgumentException("El id del cliente es obligatorio.", nameof(customerId));

        CustomerId = customerId;

        Street = street ?? throw new ArgumentNullException(nameof(street));
        Primary = primary ?? throw new ArgumentNullException(nameof(primary));
    }

    public void UpdateCustomerId(Guid customerId)
    {
        if (customerId == Guid.Empty)
            throw new ArgumentException("El id del cliente es obligatorio.", nameof(customerId));

        CustomerId = customerId;
    }

    public void UpdateStreet(CustomerAddressStreet street)
    {
        Street = street ?? throw new ArgumentNullException(nameof(street));
    }

    public void UpdatePrimary(CustomerAddressPrimary primary)
    {
        Primary = primary ?? throw new ArgumentNullException(nameof(primary));
    }
}