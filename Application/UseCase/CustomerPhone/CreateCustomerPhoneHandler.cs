using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.ValueObject.CustomerPhone;
using MediatR;
using CustomerPhoneEntity = Domain.Entities.CustomerPhones.CustomerPhone;

namespace Application.UseCase.CustomerPhone;

public sealed class CreateCustomerPhoneHandler
    : IRequestHandler<CreateCustomerPhone, Guid>
{
    private readonly IUnitOfWork _uow;

    public CreateCustomerPhoneHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Guid> Handle(
        CreateCustomerPhone request,
        CancellationToken ct)
    {
        var number = CustomerPhoneNumber.Create(request.PhoneNumber);
        var type = CustomerPhoneType.Create(request.PhoneType);

        var phone = new CustomerPhoneEntity(
            number,
            type,
            request.CustomerId);

        await _uow.CustomerPhones.AddAsync(phone, ct);
        await _uow.SaveChangesAsync(ct);

        return phone.Id;
    }
}
