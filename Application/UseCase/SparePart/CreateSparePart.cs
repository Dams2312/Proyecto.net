using System;
using MediatR;

namespace Application.UseCase.SparePart;

public sealed record CreateSparePart(
    string Code,
    string Description,
    decimal PrecioUnitario,
    int StockActual,
    int StockMinimo,
    Guid CategoryId,
    Guid UnitId,
    bool Active
) : IRequest<Guid>;
