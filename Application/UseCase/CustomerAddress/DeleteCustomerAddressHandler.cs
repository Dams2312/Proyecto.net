using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;

namespace Application.UseCase.CustomerAddress;

public sealed class DeleteCustomerAddressHandler
    : IRequestHandler<DeleteCustomerAddress, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeleteCustomerAddressHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        DeleteCustomerAddress request,
        CancellationToken ct)
    {
        var address = await _uow.CustomerAddresses.GetByIdAsync(request.Id, ct);

        if (address is null)
            throw new KeyNotFoundException("Dirección no encontrada.");

        await _uow.CustomerAddresses.RemoveAsync(address, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}
