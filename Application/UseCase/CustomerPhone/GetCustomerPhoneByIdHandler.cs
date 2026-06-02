using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using CustomerPhoneEntity = Domain.Entities.CustomerPhones.CustomerPhone;

namespace Application.UseCase.CustomerPhone;

public sealed class GetCustomerPhoneByIdHandler
    : IRequestHandler<GetCustomerPhoneById, CustomerPhoneEntity>
{
    private readonly IUnitOfWork _uow;

    public GetCustomerPhoneByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<CustomerPhoneEntity> Handle(
        GetCustomerPhoneById request,
        CancellationToken ct)
    {
        var phone = await _uow.CustomerPhones.GetByIdAsync(request.Id, ct);

        if (phone is null)
            throw new KeyNotFoundException("Teléfono no encontrado.");

        return phone;
    }
}
