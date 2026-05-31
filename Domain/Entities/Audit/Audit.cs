using System;
using Domain.common;
using Domain.ValueObject.Audit;

namespace Domain.Entities.Audit;

public sealed class Audit : BaseEntity<Guid>
{
    public Guid UserId { get; private set; }
    public Guid EntidadId { get; private set; }
    public AuditEntidad Entidad { get; private set; }
    public AuditFecha Fecha { get; private set; }
    public AuditTipoAccion TipoAccion { get; private set; }
    public AuditDatosAnteriores? DatosAnteriores { get; private set; }
    public AuditDatosNuevos? DatosNuevos { get; private set; }
    public AuditIpOrigen? IpOrigen { get; private set; }

    private Audit() { }

    public Audit(
        Guid userId,
        Guid entidadId,
        AuditEntidad entidad,
        AuditFecha fecha,
        AuditTipoAccion tipoAccion,
        AuditDatosAnteriores? datosAnteriores = null,
        AuditDatosNuevos? datosNuevos = null,
        AuditIpOrigen? ipOrigen = null)
    {
        UserId     = userId == Guid.Empty ? throw new ArgumentException(nameof(userId)) : userId;
        EntidadId  = entidadId == Guid.Empty ? throw new ArgumentException(nameof(entidadId)) : entidadId;
        Entidad    = entidad    ?? throw new ArgumentNullException(nameof(entidad));
        Fecha      = fecha      ?? throw new ArgumentNullException(nameof(fecha));
        TipoAccion = tipoAccion ?? throw new ArgumentNullException(nameof(tipoAccion));
        DatosAnteriores = datosAnteriores;
        DatosNuevos     = datosNuevos;
        IpOrigen        = ipOrigen;
    }
}