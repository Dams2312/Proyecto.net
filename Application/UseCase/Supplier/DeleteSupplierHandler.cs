using Application.Abstractions;
using MediatR;
using SupplierEntity = Domain.Entities.Supplier.Supplier;

namespace Application.UseCase.Supplier;

public sealed class DeleteSupplierHandler : IRequestHandler<DeleteSupplier, Unit>
{
    private readonly IUnitOfWork _uow;

    public DeleteSupplierHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<Unit> Handle(DeleteSupplier request, CancellationToken ct)
    {
        var supplier = await _uow.Suppliers.GetByIdAsync(request.Id, ct)
            ?? throw new KeyNotFoundException($"Proveedor con id {request.Id} no encontrado.");

        await _uow.Suppliers.RemoveAsync(supplier, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}