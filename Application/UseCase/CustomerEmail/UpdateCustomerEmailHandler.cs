using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.ValueObject.CustomerEmail;
using MediatR;

namespace Application.UseCase.CustomerEmail;

public sealed class UpdateCustomerEmailHandler
    : IRequestHandler<UpdateCustomerEmail, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateCustomerEmailHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        UpdateCustomerEmail request,
        CancellationToken ct)
    {
        var email = await _uow.CustomerEmails.GetByIdAsync(request.Id, ct);

        if (email is null)
            throw new KeyNotFoundException("Correo no encontrado.");

        var address = CustomerEmailAddress.Create(request.Address);
        var primary = CustomerEmailPrimary.Create(request.Primary);

        email.UpdateCustomerId(request.CustomerId);
        email.UpdateAddress(address);
        email.UpdatePrimary(primary);

        await _uow.CustomerEmails.UpdateAsync(email, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}
