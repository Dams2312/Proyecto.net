using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.ValueObject.CustomerPhone;
using MediatR;

namespace Application.UseCase.CustomerPhone;

public sealed class UpdateCustomerPhoneHandler
    : IRequestHandler<UpdateCustomerPhone, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateCustomerPhoneHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        UpdateCustomerPhone request,
        CancellationToken ct)
    {
        var phone = await _uow.CustomerPhones.GetByIdAsync(request.Id, ct);

        if (phone is null)
            throw new KeyNotFoundException("Teléfono no encontrado.");

        var number = CustomerPhoneNumber.Create(request.PhoneNumber);
        var type = CustomerPhoneType.Create(request.PhoneType);

        phone.UpdatePhoneNumber(number);
        phone.UpdatePhoneType(type);
        phone.UpdateCustomerId(request.CustomerId);

        await _uow.CustomerPhones.UpdateAsync(phone, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}
