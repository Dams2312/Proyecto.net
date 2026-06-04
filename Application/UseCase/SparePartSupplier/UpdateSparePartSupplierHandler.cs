using Application.Abstractions;
using Domain.ValueObject.SparePartSupplier;
using MediatR;
using SparePartSupplierEntity = Domain.Entities.SparePartSupplier.SparePartSupplier;

namespace Application.UseCase.SparePartSupplier;

public sealed class UpdateSparePartSupplierHandler : IRequestHandler<UpdateSparePartSupplier, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateSparePartSupplierHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<Unit> Handle(UpdateSparePartSupplier request, CancellationToken ct)
    {
        var entity = await _uow.SparePartSuppliers.GetByIdAsync(request.Id, ct)
            ?? throw new KeyNotFoundException($"Relación repuesto-proveedor con id {request.Id} no encontrada.");

        entity.UpdateSparePartId(SparePartSupplierSparePartId.Create(request.SparePartId));
        entity.UpdateSupplierId(SparePartSupplierSupplierId.Create(request.SupplierId));
        entity.UpdatePurchasePrice(SparePartSupplierPurchasePrice.Create(request.PurchasePrice));
        entity.UpdatePrincipal(SparePartSupplierPrincipal.Create(request.Principal));

        await _uow.SparePartSuppliers.UpdateAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}