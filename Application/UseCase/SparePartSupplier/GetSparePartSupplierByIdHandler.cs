using Application.Abstractions;
using MediatR;
using SparePartSupplierEntity = Domain.Entities.SparePartSupplier.SparePartSupplier;

namespace Application.UseCase.SparePartSupplier;

public sealed class GetSparePartSupplierByIdHandler : IRequestHandler<GetSparePartSupplierById, SparePartSupplierEntity>
{
    private readonly IUnitOfWork _uow;

    public GetSparePartSupplierByIdHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<SparePartSupplierEntity> Handle(GetSparePartSupplierById request, CancellationToken ct)
    {
        return await _uow.SparePartSuppliers.GetByIdAsync(request.Id, ct)
            ?? throw new KeyNotFoundException($"Relación repuesto-proveedor con id {request.Id} no encontrada.");
    }
}