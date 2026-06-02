using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.ValueObject.CustomerAddress;
using MediatR;

namespace Application.UseCase.CustomerAddress;

public sealed class UpdateCustomerAddressHandler
    : IRequestHandler<UpdateCustomerAddress, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateCustomerAddressHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        UpdateCustomerAddress request,
        CancellationToken ct)
    {
        var address = await _uow.CustomerAddresses.GetByIdAsync(request.Id, ct);

        if (address is null)
            throw new KeyNotFoundException("Dirección no encontrada.");

        var street = CustomerAddressStreet.Create(request.Street);
        var primary = CustomerAddressPrimary.Create(request.Primary);

        address.UpdateCustomerId(request.CustomerId);
        address.UpdateCityId(request.CityId);
        address.UpdateStreet(street);
        address.UpdatePrimary(primary);

        await _uow.CustomerAddresses.UpdateAsync(address, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}
