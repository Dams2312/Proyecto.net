using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;

namespace Application.UseCase.CustomerEmail;

public sealed class DeleteCustomerEmailHandler
    : IRequestHandler<DeleteCustomerEmail, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeleteCustomerEmailHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        DeleteCustomerEmail request,
        CancellationToken ct)
    {
        var email = await _uow.CustomerEmails.GetByIdAsync(request.Id, ct);

        if (email is null)
            throw new KeyNotFoundException("Correo no encontrado.");

        await _uow.CustomerEmails.RemoveAsync(email, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}
