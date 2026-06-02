using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using CustomerEmailEntity = Domain.Entities.CustomerEmails.CustomerEmail;

namespace Application.UseCase.CustomerEmail;

public sealed class GetCustomerEmailByIdHandler
    : IRequestHandler<GetCustomerEmailById, CustomerEmailEntity>
{
    private readonly IUnitOfWork _uow;

    public GetCustomerEmailByIdHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<CustomerEmailEntity> Handle(
        GetCustomerEmailById request,
        CancellationToken ct)
    {
        var email = await _uow.CustomerEmails.GetByIdAsync(request.Id, ct);

        if (email is null)
            throw new KeyNotFoundException("Correo no encontrado.");

        return email;
    }
}
