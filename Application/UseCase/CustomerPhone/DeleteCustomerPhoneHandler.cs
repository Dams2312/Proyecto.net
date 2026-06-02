using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;

namespace Application.UseCase.CustomerPhone;

public sealed class DeleteCustomerPhoneHandler
    : IRequestHandler<DeleteCustomerPhone, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeleteCustomerPhoneHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        DeleteCustomerPhone request,
        CancellationToken ct)
    {
        var phone = await _uow.CustomerPhones.GetByIdAsync(request.Id, ct);

        if (phone is null)
            throw new KeyNotFoundException("Teléfono no encontrado.");

        await _uow.CustomerPhones.RemoveAsync(phone, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}
