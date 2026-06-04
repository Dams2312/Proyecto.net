using Application.Abstractions;
using Domain.ValueObject.SparePartSupplier;
using MediatR;
using SparePartSupplierEntity = Domain.Entities.SparePartSupplier.SparePartSupplier;

namespace Application.UseCase.SparePartSupplier;

public sealed class CreateSparePartSupplierHandler : IRequestHandler<CreateSparePartSupplier, Guid>
{
    private readonly IUnitOfWork _uow;

    public CreateSparePartSupplierHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<Guid> Handle(CreateSparePartSupplier request, CancellationToken ct)
    {
        var entity = new SparePartSupplierEntity(
            SparePartSupplierSparePartId.Create(request.SparePartId),
            SparePartSupplierSupplierId.Create(request.SupplierId),
            SparePartSupplierPurchasePrice.Create(request.PurchasePrice),
            SparePartSupplierPrincipal.Create(request.Principal)
        );

        await _uow.SparePartSuppliers.AddAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return entity.Id;
    }
}