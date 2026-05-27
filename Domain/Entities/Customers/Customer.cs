using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.common;
using Domain.ValueObject.Customer;

namespace Domain.Entities.Customers;

public sealed class Customer : BaseEntity<Guid>
{
    public CustomerNames Names { get; private set; }
    public CustomersSurnames Surnames { get; private set; }
    public CustomerDocumentNumber DocumentNumber { get; private set; }
    public CustomersDocumentType DocumentType { get; private set; }
    public CustomerActive Active { get; private set; }
    public CustomerRegistrationDate RegistrationDate { get; private set; }
    private Customer() { }
    public Customer(CustomerNames names, CustomersSurnames surnames, CustomerDocumentNumber documentNumber, CustomersDocumentType documentType, CustomerActive active, CustomerRegistrationDate registrationDate)
    {
        Names = names ?? throw new ArgumentNullException(nameof(names));
        Surnames = surnames ?? throw new ArgumentNullException(nameof(surnames));
        DocumentNumber = documentNumber ?? throw new ArgumentNullException(nameof(documentNumber));
        DocumentType = documentType ?? throw new ArgumentNullException(nameof(documentType));
        Active = active ?? throw new ArgumentNullException(nameof(active));
        RegistrationDate = registrationDate ?? throw new ArgumentNullException(nameof(registrationDate));
    }
    public void UpdateNames(CustomerNames names)
    {
        Names = names ?? throw new ArgumentNullException(nameof(names));
    }

    public void UpdateSurnames(CustomersSurnames surnames)
    {
        Surnames = surnames ?? throw new ArgumentNullException(nameof(surnames));
    }

    public void UpdateDocumentNumber(CustomerDocumentNumber documentNumber)
    {
        DocumentNumber = documentNumber ?? throw new ArgumentNullException(nameof(documentNumber));
    }

    public void UpdateDocumentType(CustomersDocumentType documentType)
    {
        DocumentType = documentType ?? throw new ArgumentNullException(nameof(documentType));
    }

    public void UpdateActive(CustomerActive active)
    {
        Active = active ?? throw new ArgumentNullException(nameof(active));
    }
}
