using Application.Abstractions;
using Domain.ValueObject.SparePart;
using MediatR;
using SparePartEntity = Domain.Entities.SparePart.SparePart; // ← alias

namespace Application.UseCase.SparePart;

public sealed class CreateSparePartHandler : IRequestHandler<CreateSparePart, Guid>
{
    private readonly IUnitOfWork _uow;

    public CreateSparePartHandler(IUnitOfWork uow) => _uow = uow;

    public async Task<Guid> Handle(CreateSparePart request, CancellationToken ct)
    {
        var sparePart = new SparePartEntity( // ← usa el alias aquí
            SparePartCode.Create(request.Code),
            SparePartDescription.Create(request.Description),
            SparePartPrecioUnitario.Create(request.PrecioUnitario),
            SparePartStockActual.Create(request.StockActual),
            SparePartStockMinimo.Create(request.StockMinimo),
            SparePartCategoryId.Create(request.CategoryId),
            SparePartUnitId.Create(request.UnitId),
            SparePartActive.Create(request.Active)
        );

        await _uow.SpareParts.AddAsync(sparePart, ct);
        await _uow.SaveChangesAsync(ct);

        return sparePart.Id;
    }
}