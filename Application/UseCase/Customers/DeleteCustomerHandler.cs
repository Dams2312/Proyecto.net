using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using MediatR;
using Customer = Domain.Entities.Customers.Customer;

namespace Application.UseCase.Customers;

public sealed class DeleteCustomerHandler
    : IRequestHandler<DeleteCustomer, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeleteCustomerHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        DeleteCustomer request,
        CancellationToken ct)
    {
        var entity = await _uow.Customers.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("Customer no encontrado.");

        await _uow.Customers.RemoveAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}

