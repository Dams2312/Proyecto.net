using System.Threading;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities.Customers;
using Domain.ValueObject.Customer;
using MediatR;

namespace Application.UseCases.Customers;

public sealed class UpdateCustomerHandler
    : IRequestHandler<UpdateCustomer, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateCustomerHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }

    public async Task<Unit> Handle(
        UpdateCustomer request,
        CancellationToken ct)
    {
        var entity = await _uow.Customers.GetByIdAsync(request.Id, ct);

        if (entity is null)
            throw new KeyNotFoundException("Customer no encontrado.");

        entity.UpdateNames(CustomerNames.Create(request.Names));
        entity.UpdateSurnames(CustomersSurnames.Create(request.Surnames));
        entity.UpdateDocumentNumber(CustomerDocumentNumber.Create(request.DocumentNumber));
        entity.UpdateDocumentType(CustomersDocumentType.Create(request.DocumentType));
        entity.UpdateActive(CustomerActive.Create(request.Active));

        await _uow.Customers.UpdateAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}
