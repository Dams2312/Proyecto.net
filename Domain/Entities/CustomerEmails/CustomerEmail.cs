using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.common;
using Domain.ValueObject.CustomerEmail;

namespace Domain.Entities.CustomerEmails;

public sealed class CustomerEmail : BaseEntity<Guid>
{
    public EmailCustomerId CustomerId { get; private set; }
    public CustomerEmailAddress Address { get; private set; }
    public CustomerEmailPrimary Primary { get; private set; }

    private CustomerEmail() { }

    public CustomerEmail(EmailCustomerId customerId, CustomerEmailAddress address, CustomerEmailPrimary primary)
    {
        CustomerId = customerId ?? throw new ArgumentNullException(nameof(customerId));
        Address = address ?? throw new ArgumentNullException(nameof(address));
        Primary = primary ?? throw new ArgumentNullException(nameof(primary));
    }

    public void UpdateCustomerId(EmailCustomerId customerId)
    {
        CustomerId = customerId ?? throw new ArgumentNullException(nameof(customerId));
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
