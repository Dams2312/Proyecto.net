using Application.Abstractions;
using MediatR;
using SupplierEntity = Domain.Entities.Supplier.Supplier;

namespace Application.UseCase.Supplier;

public sealed class GetSupplierByIdHandler : IRequestHandler<GetSupplierById, SupplierEntity>
{
    private readonly IUnitOfWork _uow;

    public GetSupplierByIdHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<SupplierEntity> Handle(GetSupplierById request, CancellationToken ct)
    {
        return await _uow.Suppliers.GetByIdAsync(request.Id, ct)
            ?? throw new KeyNotFoundException($"Proveedor con id {request.Id} no encontrado.");
    }
}