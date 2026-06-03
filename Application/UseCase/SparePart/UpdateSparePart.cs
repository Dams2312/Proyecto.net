using System;
using MediatR;

namespace Application.UseCase.SparePart;

public sealed record UpdateSparePart(
    Guid Id,
    string Code,
    string Description,
    decimal PrecioUnitario,
    int StockActual,
    int StockMinimo,
    Guid CategoryId,
    Guid UnitId,
    bool Active
) : IRequest<Unit>;
