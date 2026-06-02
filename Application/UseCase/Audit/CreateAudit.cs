using System;
using MediatR;
using Audit = Domain.Entities.Audit.Audit;

namespace Application.UseCase.Audit;

public sealed record CreateAudit(
    Guid UserId,
    Guid EntidadId,
    string TipoAccion,
    string Entidad,
    string? DatosNuevos,
    string? DatosAnteriores,
    string? IpOrigen
) : IRequest<Guid>;

