using Application.Abstractions;
using Domain.ValueObject.Supplier;
using MediatR;
using SupplierEntity = Domain.Entities.Supplier.Supplier;

namespace Application.UseCase.Supplier;

public sealed class CreateSupplierHandler : IRequestHandler<CreateSupplier, Guid>
{
    private readonly IUnitOfWork _uow;

    public CreateSupplierHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<Guid> Handle(CreateSupplier request, CancellationToken ct)
    {
        var supplier = new SupplierEntity(
            SupplierName.Create(request.Name),
            SupplierNit.Create(request.Nit),
            SupplierEmail.Create(request.Email),
            SupplierPhone.Create(request.Phone),
            request.CityId,
            SupplierActive.Create(request.Active)
        );

        await _uow.Suppliers.AddAsync(supplier, ct);
        await _uow.SaveChangesAsync(ct);

        return supplier.Id;
    }
}