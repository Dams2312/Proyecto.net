using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.CustomerAddresses;
using Domain.ValueObject.CustomerAddress;
using MediatR;
using CustomerAddressEntity = Domain.Entities.CustomerAddresses.CustomerAddress;

namespace Application.UseCase.CustomerAddress;

public sealed class CreateCustomerAddressHandler
    : IRequestHandler<CreateCustomerAddress, Guid>
{
    private readonly IUnitOfWork _uow;

    public CreateCustomerAddressHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Guid> Handle(
        CreateCustomerAddress request,
        CancellationToken ct)
    {
        var cityId = CustomerCityId.Create(request.CityId);
        var street = CustomerAddressStreet.Create(request.Street);
        var primary = CustomerAddressPrimary.Create(request.Primary);

        var address = new CustomerAddressEntity(
            request.CustomerId,
            cityId.Value,
            street,
            primary);

        await _uow.CustomerAddresses.AddAsync(address, ct);
        await _uow.SaveChangesAsync(ct);

        return address.Id;
    }
}
