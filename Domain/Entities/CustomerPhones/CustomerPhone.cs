using System;
using Domain.common;
using Domain.ValueObject.CustomerPhone;

namespace Domain.Entities.CustomerPhones;

public sealed class CustomerPhone : BaseEntity<Guid>
{
    public CustomerPhoneNumber PhoneNumber { get; private set; }

    public CustomerPhoneType PhoneType { get; private set; }

    // FK COMO GUID
    public Guid CustomerId { get; private set; }

    private CustomerPhone() { }

    public CustomerPhone(
        CustomerPhoneNumber phoneNumber,
        CustomerPhoneType phoneType,
        Guid customerId)
    {
        PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));

        PhoneType = phoneType ?? throw new ArgumentNullException(nameof(phoneType));

        if (customerId == Guid.Empty)
            throw new ArgumentException("El id del cliente es obligatorio.", nameof(customerId));

        CustomerId = customerId;
    }

    public void UpdatePhoneNumber(CustomerPhoneNumber phoneNumber)
    {
        PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
    }

    public void UpdatePhoneType(CustomerPhoneType phoneType)
    {
        PhoneType = phoneType ?? throw new ArgumentNullException(nameof(phoneType));
    }

    public void UpdateCustomerId(Guid customerId)
    {
        if (customerId == Guid.Empty)
            throw new ArgumentException("El id del cliente es obligatorio.", nameof(customerId));

        CustomerId = customerId;
    }
}