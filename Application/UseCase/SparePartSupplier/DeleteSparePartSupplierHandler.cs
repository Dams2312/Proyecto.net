using Application.Abstractions;
using MediatR;
using SparePartSupplierEntity = Domain.Entities.SparePartSupplier.SparePartSupplier;

namespace Application.UseCase.SparePartSupplier;

public sealed class DeleteSparePartSupplierHandler : IRequestHandler<DeleteSparePartSupplier, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeleteSparePartSupplierHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<Unit> Handle(DeleteSparePartSupplier request, CancellationToken ct)
    {
        var entity = await _uow.SparePartSuppliers.GetByIdAsync(request.Id, ct)
            ?? throw new KeyNotFoundException($"Relación repuesto-proveedor con id {request.Id} no encontrada.");

        await _uow.SparePartSuppliers.RemoveAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}