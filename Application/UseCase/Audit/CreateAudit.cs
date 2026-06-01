using System;
using MediatR;

namespace Application.UseCases.Audit;

public sealed record CreateAudit(
    string TipoAccion,
    string Entidad,
    string? DatosNuevos,
    string? DatosAnteriores,
    string? IpOrigen
) : IRequest<Guid>;
