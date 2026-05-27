using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.common;
using Domain.ValueObject.CustomerPhone;

namespace Domain.Entities.CustomerPhones;

public sealed class CustomerPhone : BaseEntity<Guid>
{
    public CustomerPhoneNumber PhoneNumber { get; private set; }
    public CustomerPhoneType PhoneType { get; private set; }
    public PhoneCustomerId CustomerId { get; private set; }
    private CustomerPhone() { }
    public CustomerPhone(CustomerPhoneNumber phoneNumber, CustomerPhoneType phoneType, PhoneCustomerId customerId)
    {
        PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
        PhoneType = phoneType ?? throw new ArgumentNullException(nameof(phoneType));
        CustomerId = customerId ?? throw new ArgumentNullException(nameof(customerId));
    }
    public void UpdatePhoneNumber(CustomerPhoneNumber phoneNumber)
    {
        PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
    }

    public void UpdatePhoneType(CustomerPhoneType phoneType)
    {
        PhoneType = phoneType ?? throw new ArgumentNullException(nameof(phoneType));
    }
}
