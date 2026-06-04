using Application.Abstractions;
using Domain.ValueObject.Supplier;
using MediatR;
using SupplierEntity = Domain.Entities.Supplier.Supplier;

namespace Application.UseCase.Supplier;

public sealed class UpdateSupplierHandler : IRequestHandler<UpdateSupplier, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateSupplierHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<Unit> Handle(UpdateSupplier request, CancellationToken ct)
    {
        var supplier = await _uow.Suppliers.GetByIdAsync(request.Id, ct)
            ?? throw new KeyNotFoundException($"Proveedor con id {request.Id} no encontrado.");

        supplier.UpdateName(SupplierName.Create(request.Name));
        supplier.UpdateNit(SupplierNit.Create(request.Nit));
        supplier.UpdateEmail(SupplierEmail.Create(request.Email));
        supplier.UpdatePhone(SupplierPhone.Create(request.Phone));
        supplier.UpdateCityId(request.CityId);
        supplier.UpdateActive(SupplierActive.Create(request.Active));

        await _uow.Suppliers.UpdateAsync(supplier, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}