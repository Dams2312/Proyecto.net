using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.common;
using Domain.ValueObject.SparePart;

namespace Domain.Entities.SparePart;

public sealed class SparePart : BaseEntity<Guid>
{
    public SparePartCode Code { get; private set; }
    public SparePartDescription Description { get; private set; }
    public SparePartPrecioUnitario PrecioUnitario { get; private set; }
    public SparePartStockActual StockActual { get; private set; }
    public SparePartStockMinimo StockMinimo { get; private set; }
    public SparePartCategoryId CategoryId { get; private set; }
    public SparePartUnitId UnitId { get; private set; }
    public SparePartActive Active { get; private set; }

    private SparePart() { }

    public SparePart(
        SparePartCode code,
        SparePartDescription description,
        SparePartPrecioUnitario precioUnitario,
        SparePartStockActual stockActual,
        SparePartStockMinimo stockMinimo,
        SparePartCategoryId categoryId,
        SparePartUnitId unitId,
        SparePartActive active)
    {
        if (stockActual.Value < stockMinimo.Value)
            throw new ArgumentException("El stock actual no puede ser menor que el stock mínimo.", nameof(stockActual));

        Code = code ?? throw new ArgumentNullException(nameof(code));
        Description = description ?? throw new ArgumentNullException(nameof(description));
        PrecioUnitario = precioUnitario ?? throw new ArgumentNullException(nameof(precioUnitario));
        StockActual = stockActual ?? throw new ArgumentNullException(nameof(stockActual));
        StockMinimo = stockMinimo ?? throw new ArgumentNullException(nameof(stockMinimo));
        CategoryId = categoryId ?? throw new ArgumentNullException(nameof(categoryId));
        UnitId = unitId ?? throw new ArgumentNullException(nameof(unitId));
        Active = active ?? throw new ArgumentNullException(nameof(active));
    }

    public void UpdateCode(SparePartCode code)
    {
        Code = code ?? throw new ArgumentNullException(nameof(code));
    }

    public void UpdateDescription(SparePartDescription description)
    {
        Description = description ?? throw new ArgumentNullException(nameof(description));
    }

    public void UpdatePrecioUnitario(SparePartPrecioUnitario precioUnitario)
    {
        PrecioUnitario = precioUnitario ?? throw new ArgumentNullException(nameof(precioUnitario));
    }

    public void UpdateStockActual(SparePartStockActual stockActual)
    {
        if (stockActual is null)
            throw new ArgumentNullException(nameof(stockActual));

        if (stockActual.Value < StockMinimo.Value)
            throw new ArgumentException("El stock actual no puede ser menor que el stock mínimo.", nameof(stockActual));

        StockActual = stockActual;
    }

    public void UpdateStockMinimo(SparePartStockMinimo stockMinimo)
    {
        if (stockMinimo is null)
            throw new ArgumentNullException(nameof(stockMinimo));

        if (StockActual.Value < stockMinimo.Value)
            throw new ArgumentException("El stock mínimo no puede ser mayor que el stock actual.", nameof(stockMinimo));

        StockMinimo = stockMinimo;
    }

    public void UpdateCategoryId(SparePartCategoryId categoryId)
    {
        CategoryId = categoryId ?? throw new ArgumentNullException(nameof(categoryId));
    }

    public void UpdateUnitId(SparePartUnitId unitId)
    {
        UnitId = unitId ?? throw new ArgumentNullException(nameof(unitId));
    }

    public void UpdateActive(SparePartActive active)
    {
        Active = active ?? throw new ArgumentNullException(nameof(active));
    }
}
