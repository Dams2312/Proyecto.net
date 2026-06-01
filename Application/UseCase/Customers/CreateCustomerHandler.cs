using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.Customers;
using Domain.ValueObject.Customer;
using MediatR;

namespace Application.UseCases.Customers;

public sealed class CreateCustomerHandler
    : IRequestHandler<CreateCustomer, Guid>
{
    private readonly IUnitOfWork _uow;

    public CreateCustomerHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Guid> Handle(
        CreateCustomer request,
        CancellationToken ct)
    {
        var names = CustomerNames.Create(request.Names);

        var surnames = CustomersSurnames.Create(request.Surnames);

        var documentNumber =
            CustomerDocumentNumber.Create(request.DocumentNumber);

        var documentType =
            CustomersDocumentType.Create(request.DocumentType);

        var active =
            CustomerActive.Create(request.Active);

        var registrationDate =
            CustomerRegistrationDate.Create(DateOnly.FromDateTime(DateTime.UtcNow));

        var customer = new Customer(
            names,
            surnames,
            documentNumber,
            documentType,
            active,
            registrationDate);

        await _uow.Customers.AddAsync(customer, ct);

        await _uow.SaveChangesAsync(ct);

        return customer.Id;
    }
}
