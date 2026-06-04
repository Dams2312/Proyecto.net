using Application.Abstractions;
using Domain.ValueObject.SparePart;
using MediatR;
using SparePartEntity = Domain.Entities.SparePart.SparePart;

namespace Application.UseCase.SparePart;

public sealed class UpdateSparePartHandler : IRequestHandler<UpdateSparePart, Unit>
{
    private readonly IUnitOfWork _uow;

    public UpdateSparePartHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<Unit> Handle(UpdateSparePart request, CancellationToken ct)
    {
        var entity = await _uow.SpareParts.GetByIdAsync(request.Id, ct)
            ?? throw new KeyNotFoundException($"Repuesto con id {request.Id} no encontrado.");

        entity.UpdateCode(SparePartCode.Create(request.Code));
        entity.UpdateDescription(SparePartDescription.Create(request.Description));
        entity.UpdatePrecioUnitario(SparePartPrecioUnitario.Create(request.PrecioUnitario));
        entity.UpdateStockMinimo(SparePartStockMinimo.Create(request.StockMinimo));
        entity.UpdateStockActual(SparePartStockActual.Create(request.StockActual));
        entity.UpdateCategoryId(SparePartCategoryId.Create(request.CategoryId));
        entity.UpdateUnitId(SparePartUnitId.Create(request.UnitId));
        entity.UpdateActive(SparePartActive.Create(request.Active));

        await _uow.SpareParts.UpdateAsync(entity, ct);
        await _uow.SaveChangesAsync(ct);

        return Unit.Value;
    }
}