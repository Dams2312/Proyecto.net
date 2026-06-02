using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.ValueObject.CustomerEmail;
using MediatR;
using CustomerEmailEntity = Domain.Entities.CustomerEmails.CustomerEmail;

namespace Application.UseCase.CustomerEmail;

public sealed class CreateCustomerEmailHandler
    : IRequestHandler<CreateCustomerEmail, Guid>
{
    private readonly IUnitOfWork _uow;

    public CreateCustomerEmailHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Guid> Handle(
        CreateCustomerEmail request,
        CancellationToken ct)
    {
        var address = CustomerEmailAddress.Create(request.Address);
        var primary = CustomerEmailPrimary.Create(request.Primary);

        var email = new CustomerEmailEntity(
            request.CustomerId,
            address,
            primary);

        await _uow.CustomerEmails.AddAsync(email, ct);
        await _uow.SaveChangesAsync(ct);

        return email.Id;
    }
}
