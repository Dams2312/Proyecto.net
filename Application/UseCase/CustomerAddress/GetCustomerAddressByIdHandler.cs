using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using CustomerAddressEntity = Domain.Entities.CustomerAddresses.CustomerAddress;

namespace Application.UseCase.CustomerAddress;

public sealed class GetCustomerAddressByIdHandler
    : IRequestHandler<GetCustomerAddressById, CustomerAddressEntity>
{
    private readonly IUnitOfWork _uow;

    public GetCustomerAddressByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<CustomerAddressEntity> Handle(
        GetCustomerAddressById request,
        CancellationToken ct)
    {
        var address = await _uow.CustomerAddresses.GetByIdAsync(request.Id, ct);

        if (address is null)
            throw new KeyNotFoundException("Dirección no encontrada.");

        return address;
    }
}
