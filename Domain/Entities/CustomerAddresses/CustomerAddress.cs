using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.common;
using Domain.ValueObject.CustomerAddress;

namespace Domain.Entities.CustomerAddresses;

public sealed class CustomerAddress : BaseEntity<Guid>
{
    public AddressCustomerId CustomerId { get; private set; }
    public CustomerAddressStreet Street { get; private set; }
    public CustomerAddressPrimary Primary { get; private set; }

    private CustomerAddress() { }

    public CustomerAddress(AddressCustomerId customerId, CustomerAddressStreet street, CustomerAddressPrimary primary)
    {
        CustomerId = customerId ?? throw new ArgumentNullException(nameof(customerId));
        Street = street ?? throw new ArgumentNullException(nameof(street));
        Primary = primary ?? throw new ArgumentNullException(nameof(primary));
    }

    public void UpdateCustomerId(AddressCustomerId customerId)
    {
        CustomerId = customerId ?? throw new ArgumentNullException(nameof(customerId));
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
